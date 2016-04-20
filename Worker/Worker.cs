using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using NaverCafe.Manager;

namespace NaverCafe.Worker

{
    class Worker : BackgroundWorker
    {
        public Worker()
        {
            WorkerReportsProgress = true;
            WorkerSupportsCancellation = true;
        }

        public int Interval { private get; set; }
        public People People { private get; set; }
        public List<CampSite> campSites { private get; set; }
        
        protected override void OnDoWork(DoWorkEventArgs e)
        {
            while (!CancellationPending)
            {
                foreach (var campSite in campSites)
                {
                    string message = null;

                    var canReservation = HttpManager.PossibleReservation(campSite.StartDate, campSite.Idx,
                        campSite.SiteName);
                    if (!string.IsNullOrEmpty(canReservation))
                    {
                        new GcmManager().SendNotification("날짜찾기 성공", campSite.CampName);

                        campSite.RoomCount = HttpManager.GetFreeRoomCount(campSite.StartDate, campSite.Idx,
                            campSite.GroupIdx);
                        var cost = HttpManager.GetCost(campSite.StartDate, campSite.SiteNumber, campSite.GroupIdx);
                        campSite.Cost = int.Parse(cost);

                        var resultHtml = HttpManager.DoReservation(People, campSite);

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

                            message = string.Format("{0} {1}", "성공", campSite.StartDate.ToString("MM-dd"));

                            new GcmManager().SendNotification(message, campSite.CampName);

                            ReportProgress(0, message);

                            CancelAsync();
                            break;

                        }
                    }
                    else
                    {
                        message = string.Format("{0} {1}", "자리없음", campSite.StartDate.ToString("yyyy-MM-dd"));
                    }



                    ReportProgress(0, message);
                    Thread.Sleep(1000);
                }
            }
        }
    }
}
