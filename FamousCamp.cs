using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using NaverCafe.Manager;

namespace NaverCafe
{
    public partial class FamousCamp : Form
    {
        private readonly Worker.Worker _worker = new Worker.Worker();

        public FamousCamp()
        {
            InitializeComponent();

            monthCalendar1.SelectionStart = DateTime.Now.AddDays(6 - (int) DateTime.Now.DayOfWeek);
            monthCalendar1.SelectionEnd = DateTime.Now.AddDays(6 - (int) DateTime.Now.DayOfWeek + 1);

            lbCamp.Items.Add(new Tuple<string, int>("호명산두레캠핑장", 590));
            lbCamp.Items.Add(new Tuple<string, int>("중바위캠핑장", 343));
            lbCamp.Items.Add(new Tuple<string, int>("구름계곡오토캠핑장", 362));
            lbCamp.Items.Add(new Tuple<string, int>("법흥계곡석천캠핑장", 614));
            lbCamp.Items.Add(new Tuple<string, int>("아침고요오토캠핑장", 542));

            lbCamp.DisplayMember = "Item1";
            lbCamp.ValueMember = "Item2";
            lbCamp.SelectedIndexChanged += lbCamp_SelectedIndexChanged;

            btnInsert.Enabled = false;

            lbSite.DisplayMember = "Item1";
            lbSite.ValueMember = "Item2";

            lbSiteNumber.DisplayMember = "Item1";
            lbSiteNumber.ValueMember = "Item2";

            _worker.ProgressChanged += worker_ProgressChanged;
            _worker.RunWorkerCompleted += worker_RunWorkerCompleted;
        }

        #region worker

        private void worker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            if (txtLog.Lines.Length <= 30)
            {
                Util.Logging(txtLog, e.UserState.ToString());
            }
            else
            {
                txtLog.Clear();
                Util.Logging(txtLog, e.UserState.ToString());
            }
        }

        private void worker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            Util.Logging(txtLog, "완료~!!");
            btnStartReservation.Enabled = true;
            btnStartReservation.Text = @"예약시작";
        }

        #endregion

        private void lbCamp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbCamp.SelectedItem == null) return;

            var idx = ((Tuple<string, int>) lbCamp.SelectedItem).Item2;
            var sites = HttpManager.GetSites(DateTime.Now.AddDays(1), idx);

            lbSite.DataSource = (from site in sites
                select new Tuple<string, int>(site.Split('|')[1], int.Parse(site.Split('|')[0]))).ToList();
        }

        private void lbSite_SelectedIndexChanged(object sender, EventArgs e)
        {
            var idx = ((Tuple<string, int>) lbCamp.SelectedItem).Item2;
            var groupIdx = ((Tuple<string, int>) lbSite.SelectedItem).Item2;
            var siteNumbers = HttpManager.GetSitesNumber(monthCalendar1.SelectionStart, idx, groupIdx);

            lbSiteNumber.DataSource = (from site in siteNumbers
                select new Tuple<string, int>(site.Split('|')[1], int.Parse(site.Split('|')[0]))).ToList();


            var reservationInfo = HttpManager.GetSiteReservationInfo(monthCalendar1.SelectionStart, idx, groupIdx);

            cbPeople.Items.Clear();
            for (int i = 0; i < reservationInfo.Item1; i++)
            {
                cbPeople.Items.Add(i + "명");
            }
            cbPeople.SelectedIndex = 0;

            cbStayDay.Items.Clear();
            for (int i = 1; i - 1 < reservationInfo.Item2; i++)
            {
                cbStayDay.Items.Add(i + "박");
            }

            if (cbStayDay.Items.Count == 0) cbStayDay.Items.Add("2박");

            if (cbStayDay.Items.Count > 1) cbStayDay.SelectedIndex = 0;

            btnInsert.Enabled = true;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            var reservationString = string.Format("{3} | {0} | {1} | {2} | {4}",
                ((Tuple<string, int>) lbCamp.SelectedItem).Item1, lbSite.Text, lbSiteNumber.Text,
                monthCalendar1.SelectionStart.ToString("yyyy/MM/dd"), cbStayDay.Text);
            lbReservation.Items.Add(
                new Tuple<string, CampSite>(
                    reservationString,
                    new CampSite()
                    {
                        Idx = ((Tuple<string, int>) lbCamp.SelectedItem).Item2,
                        CampName = ((Tuple<string, int>) lbCamp.SelectedItem).Item1,
                        GroupIdx = ((Tuple<string, int>) lbSite.SelectedItem).Item2,
                        SiteName = ((Tuple<string, int>) lbSite.SelectedItem).Item1,
                        SiteNumber = ((Tuple<string, int>) lbSiteNumber.SelectedItem).Item2,
                        SiteNumberName = ((Tuple<string, int>) lbSiteNumber.SelectedItem).Item1,
                        PeopleCount = cbPeople.SelectedIndex,
                        StayDay = int.Parse(cbStayDay.Text.Replace("박", "")),
                        StartDate = monthCalendar1.SelectionStart,
                        Classnum = "N"
                    }
                    ));
            lbReservation.DisplayMember = "Item1";
            lbReservation.ValueMember = "Item2";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            lbReservation.Items.RemoveAt(lbReservation.SelectedIndex);
        }

        private void btnStartReservation_Click(object sender, EventArgs e)
        {
            if (btnStartReservation.Text == "예약시작")
            {
                var people = new People
                {
                    Name = txtName.Text,
                    CarNumber = int.Parse(txtCarNumber.Text),
                    CellPhone1 = txtCell.Text.Split('-')[0],
                    CellPhone2 = txtCell.Text.Split('-')[1],
                    CellPhone3 = txtCell.Text.Split('-')[2],
                    Email1 = txtEmail.Text.Split('@')[0],
                    Email2 = txtEmail.Text.Split('@')[1]
                };

                _worker.Interval = 1;
                _worker.campSites =
                    (from object item in lbReservation.Items select ((Tuple<string, CampSite>)item).Item2).ToList();
                _worker.People = people;
                _worker.RunWorkerAsync();

                btnStartReservation.Text = "예약중지";
            }
            else
            {
                _worker.CancelAsync();
            }
            

            #region

            /*
            while (true)
            {
                foreach (var item in lbReservation.Items)
                {
                    var campSite = ((Tuple<string, CampSite>) item).Item2;


                    var canReservation = HttpManager.PossibleReservation(campSite.StartDate, campSite.Idx,
                        campSite.SiteName);
                    if (!string.IsNullOrEmpty(canReservation))
                    {
                        campSite.RoomCount = HttpManager.GetFreeRoomCount(campSite.StartDate, campSite.Idx,
                            campSite.GroupIdx);
                        var cost = HttpManager.GetCost(campSite.StartDate, campSite.SiteNumber, campSite.GroupIdx);
                        campSite.Cost = int.Parse(cost);

                        


                        var resultHtml = HttpManager.DoReservation(people, campSite);

                        //GcmManager.SendNotification("과천" + message, castItem.Item1);

                        int startIndex = 0;
                        string startText = "src=";
                        string endText = "\"";

                        while (true)
                        {
                            startIndex = resultHtml.IndexOf(startText, startIndex + 1);
                            if (startIndex == -1)
                            {
                                break;
                            }
                            string resultText =
                                resultHtml.Substring(startIndex + startText.Length,
                                    resultHtml.IndexOf(endText, startIndex) - startIndex - startText.Length)
                                    .Trim();
                            HttpManager.SendSms(resultText);
                            break;

                        }
                    }
                    Thread.Sleep(1000);
                }*/

            #endregion
        }
    }
}