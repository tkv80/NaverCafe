using System;
using System.Text;
using System.Windows.Forms;

namespace NaverCafe
{
    static class Program
    {
        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            var dd = System.Web.HttpUtility.UrlDecode(
                "campidx=542&classnum=N&ddate=2014-07-16&ri=1&gidx=486&roomCount=11&roomChk=0&roomCnt=1&r10=%C6%C4%BC%E2%BC%AEB%B1%B8%BF%AA&rr0=%C6%C4%BC%E2%BC%AEB%B1%B8%BF%AA&rr10=90000&rTo0=0&b0=2&m0=&rdidx0=912&cnt0=&rr20=35000&date0=2014-07-16&dateEnd0=2014-07-17&dc_cost0=0&base_cost0=35000&people_cost0=5000&r11=%C6%C4%BC%E2%BC%AEB%B1%B8%BF%AA&rr1=%C6%C4%BC%E2%BC%AEB%B1%B8%BF%AA&rr11=90000&rTo1=0&b1=2&m1=&rdidx1=912&cnt1=&rr21=35000&date1=2014-07-17&dateEnd1=2014-07-18&dc_cost1=10000&base_cost1=35000&people_cost1=5000&r12=%C6%C4%BC%E2%BC%AEB%B1%B8%BF%AA&rr2=%C6%C4%BC%E2%BC%AEB%B1%B8%BF%AA&rr12=90000&rTo2=0&b2=2&m2=&rdidx2=912&cnt2=&rr22=35000&date2=2014-07-18&dateEnd2=2014-07-19&dc_cost2=10000&base_cost2=40000&people_cost2=5000&roomtotal=90000&count=3&oi=0&optCount=0&optChk=&optCnt=0&optiontotal=0&agree=on&name=%B1%E8%C5%C2%B1%C7&hp1=010&hp2=8226&hp3=7979&email1=tkv80&email2=naver.com&user_car_num=7896&send_message=&pay_type=%B9%AB%C5%EB%C0%E5&bankinfo=%5B%B3%F3%C7%F9%5D+2270-5152-016058+%28%BF%B9%B1%DD%C1%D6%3A%C1%A4%B1%B8%C0%CF%29&gopaymethod=&goodname=%BC%B1%C0%CE%C0%E5&buyername=%C8%AB%B1%E6%B5%BF&buyeremail=hkd%40abcd.com&buyertel=010-1234-5678&acceptmethod=SKIN%28ORIGINAL%29%3AHPP%281%29&oid=Merchant_Order_ID&INIregno=&ini_encfield=&ini_certid=&quotainterest=&paymethod=&cardcode=&cardquota=&rbankcode=&reqsign=DONE&encrypted=&sessionkey=&uid=&sid=&version=4000&clickcontrol=enable",
                Encoding.GetEncoding("euc-kr"));


            var dd1 = System.Web.HttpUtility.UrlDecode(
                "campidx=614&classnum=Y&ddate=2014-07-19&ri=1&gidx=529&roomCount=9&roomChk=8&roomCnt=1&r10=%B3%C1%B0%A1%BB%E7%C0%CC%C6%AE&rr0=%B3%C1%B0%A120&rr10=40000&rTo0=0&b0=0&m0=&rdidx0=1002&cnt0=&rr20=40000&date0=2014-07-19&dateEnd0=2014-07-20&dc_cost0=0&base_cost0=40000&people_cost0=5000&roomtotal=40000&count=1&oi=0&optCount=0&optChk=&optCnt=0&optiontotal=0&agree=on&name=%B1%E8%C5%C2%B1%C7&hp1=010&hp2=8226&hp3=7979&email1=tkv80&email2=naver.com&user_car_num=7896&send_message=&pay_type=%B9%AB%C5%EB%C0%E5&bankinfo=%5B%BD%C5%C7%D1%5D+110-273-838676+%28%BF%B9%B1%DD%C1%D6%3A%C7%D1%B9%E9%BC%F6%29&gopaymethod=&goodname=%BC%B1%C0%CE%C0%E5&buyername=%C8%AB%B1%E6%B5%BF&buyeremail=hkd%40abcd.com&buyertel=010-1234-5678&acceptmethod=SKIN%28ORIGINAL%29%3AHPP%281%29&oid=Merchant_Order_ID&INIregno=&ini_encfield=&ini_certid=&quotainterest=&paymethod=&cardcode=&cardquota=&rbankcode=&reqsign=DONE&encrypted=&sessionkey=&uid=&sid=&version=4000&clickcontrol=enable",
                Encoding.GetEncoding("euc-kr"));

            var dd2 = System.Web.HttpUtility.UrlDecode(
                "http://www.campingsearch.co.kr/sms/smsSend.asp?cTranmsg=[%B1%E8%C5%C2%B1%C7]2014-07-22%20%BF%B9%BE%E0%C1%A2%BC%F6%20%B5%C7%BE%FA%BD%C0%B4%CF%B4%D9.%2001082267979&cTranphone=01047342578&cTrancallback=01082267979 HTTP/1.1",
                Encoding.GetEncoding("euc-kr"));


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Reservation());
            Application.Run(new FamousCamp());
        }
    }
}
