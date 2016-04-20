using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NaverCafe.Manager;

namespace NaverCafe
{
    public partial class Reservation : Form
    {
        readonly Dictionary<string, List<string>> _map = HttpManager.GetMap();

        public Reservation()
        {
            InitializeComponent();

            cbLocation.DataSource = _map.Keys.ToList();
            cbLocation.SelectedIndexChanged += cbLocation_SelectedIndexChanged;

            lbFamous.Items.Add(new Tuple<string, int>("호명산두레캠핑장", 590));
            lbFamous.Items.Add(new Tuple<string, int>("중바위캠핑장", 343));
        }

        void cbLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbCity.DataSource = _map[cbLocation.Text].ToList();
        }

        private void Reservation_Load(object sender, EventArgs e)
        {
            for (int i = 1; i < 500; i++)
            {
                
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var dd =
                System.Web.HttpUtility.UrlDecode(
                    "http://www.campingsearch.co.kr/campReserve/reserveTableInfo_1.asp?optiontotal=0&roomtotal=40%2C000%BF%F8&oi=0&gidx=117&campidx=343&ri=1&ddate=2014-07-13&roomCount=15&roomChk=0&roomCnt=1&optCount=0&optChk=&optCnt=0&classnum=N&r10=%C4%B7%C7%CE%281%7E5%B9%DA%29&rr0=%C4%B7%C7%CE%281%7E5%B9%DA%29&rr10=40000&rTo0=0&b0=1&m0=&rdidx0=238&cnt0=&rr20=40000", Encoding.GetEncoding("euc-kr"));
            var dd1 =
                System.Web.HttpUtility.UrlDecode(
                    "http://gunmoni.weblog.cafe24.com/weblog.html?uid=gunmoni&udim=1920*1080&uref=http://www.campingsearch.co.kr/campReserve/reserveTableStatus.asp?c_year=2014&c_month=8&idx=590&uname=%C4%B7%C7%CE%BC%AD%C4%A1&url=http://www.campingsearch.co.kr/campReserve/reserveTableStatus.asp?c_year=2014&c_month=7&idx=590 HTTP/1.1", Encoding.GetEncoding("euc-kr"));

            var date = DateTime.Now.AddDays(-3);

            var sites = HttpManager.GetSites(date, 343);
            HttpManager.PossibleReservation(date, 343,"");
        }

        private void btnReservation_Click(object sender, EventArgs e)
        {

        }

        private void btnInsert_Click(object sender, EventArgs e)
        {

        }
    }
}
