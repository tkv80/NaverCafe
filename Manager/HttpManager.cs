using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Web;
using System.Xml.Linq;

namespace NaverCafe.Manager
{
    internal static class HttpManager
    {

        /// <summary>
        /// 한국 지역 정보
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, List<string>> GetMap()
        {
            XDocument xdoc = XDocument.Load("http://www.campingsearch.co.kr/images/korea_map.xml");
            var map = new Dictionary<string, List<string>>();

            map.Add("전체", new List<string>{""});
            if (xdoc.Root == null) return map;

            foreach (var element in xdoc.Root.Elements())
            {
                var cityies = element.Elements().Select(child => child.Name.ToString()).ToList();
                map.Add(element.Name.ToString(), cityies);

            }
            return map;
        }

        /// <summary>
        ///  지역별 검색
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<string> GetCampground(string location, string city)
        {
            try
            {
                var httpWRequest =
                    (HttpWebRequest)
                        WebRequest.Create(
                            string.Format(
                                "http://www.campingsearch.co.kr/campReserve/campReserveInfoCal2.asp?sido={0}&gugun={1}&room_type=8&opt=1&one_day=&start_day=&end_day=&internet_yn=&electricity_yn=&warm_yn=&shower_yn=&swim_yn=&lodging_yn=&caravan_yn=&winter_yn=",
                                location, city
                                ));
                httpWRequest.Method = "get";

                var theResponse = (HttpWebResponse) httpWRequest.GetResponse();
                var sr = new StreamReader(theResponse.GetResponseStream());

                string resultHtml = sr.ReadToEnd();

                int startIndex = 0;
                string startText = "<code>";
                string endText = "</codenm>";

                var sites = new List<string>();
                while (true)
                {
                    try
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

                        if (resultText.Contains("</code><codenm>"))
                        {
                            resultText = resultText.Replace("</code><codenm>", "|");
                            sites.Add(resultText);
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                }


                return sites;
            }
            catch (Exception ex)
            {
                Util.ErrorLog(MethodBase.GetCurrentMethod(), ex, "에러");
                return null;
            }
        }

        /// <summary>
        /// 사이트 정보 가져오기
        /// </summary>
        /// <param name="date"></param>
        /// <param name="idx"></param>
        /// <returns></returns>
        public static IEnumerable<string> GetSites(DateTime date, int idx)
        {
            var httpWRequest =
                (HttpWebRequest)
                    WebRequest.Create(
                        string.Format(
                            "http://www.campingsearch.co.kr/campReserve/groupIfrm.asp?idx={1}&ddate={0}&week=undefined",
                            date.ToString("yyyy-MM-dd"), idx));
            httpWRequest.UserAgent = "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.1; WOW64; Trident/6.0)";
            httpWRequest.KeepAlive = true;
            httpWRequest.Method = "Get";
            httpWRequest.Referer =
                string.Format(" http://www.campingsearch.co.kr/campReserve/reserveTableInfo.asp?idx={0}", idx);

            var theResponse = (HttpWebResponse) httpWRequest.GetResponse();
            var sr = new StreamReader(theResponse.GetResponseStream(), Encoding.GetEncoding("euc-kr"));

            var resultHtml = sr.ReadToEnd();

            var sites = new List<string>();

            int startIndex = 0;
            string startText = "<td><label for=\"group";
            string endText = "</label></td>";

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

                if (!resultText.Contains("<font") && !resultText.Contains("/"))
                {
                    var validString = resultText.Replace("group", "");
                    validString = validString.Replace("\">", "|");
                    sites.Add(validString);
                }

            }
            return sites;



            //try
            //{
            //    var httpWRequest =
            //        (HttpWebRequest)WebRequest.Create(string.Format("http://www.campingsearch.co.kr/campReserve/reserveTableStatus.asp?c_year={0}&c_month={1}&idx={2}",
            //        date.Year, date.Month, idx));
            //    httpWRequest.UserAgent = "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.1; WOW64; Trident/6.0)";
            //    httpWRequest.KeepAlive = true;
            //    httpWRequest.Method = "Get";
            //    httpWRequest.Referer = string.Format("http://www.campingsearch.co.kr/campReserve/reserveTableStatus.asp?c_year={0}&c_month={1}&idx={2}", date.Year, date.Month, idx);

            //    var theResponse = (HttpWebResponse)httpWRequest.GetResponse();
            //    var sr = new StreamReader(theResponse.GetResponseStream(), Encoding.GetEncoding("euc-kr"));

            //    var resultHtml = sr.ReadToEnd();


            //    var searchDate = date;
            //    var sites = new List<string>();

            //    while (true)
            //    {
            //        if (searchDate.Month != date.Month) break;

            //        if (resultHtml.IndexOf(string.Format("num11><b>{0}", searchDate.Day))  ==-1 )break;

            //        var searchHtml = resultHtml.Substring(string.Format("num11><b>{0}", searchDate.Day), "</table>");

            //        int startIndex = 0;
            //        string startText = "<td>";
            //        string endText = "/td>";

            //        if (startIndex >= searchHtml.Length) break;

            //        while (true)
            //        {
            //            startIndex = searchHtml.IndexOf(startText, startIndex + 1);
            //            if (startIndex == -1)
            //            {
            //                break;
            //            }
            //            string resultText =
            //                searchHtml.Substring(startIndex + startText.Length,
            //                    searchHtml.IndexOf(endText, startIndex) - startIndex - startText.Length)
            //                    .Trim();

            //            try
            //            {
            //                var splitString = resultText.Split('<');
            //                if (splitString.Length ==3)
            //                {
            //                    var validString = splitString[1].Substring(">");
            //                    sites.Add(validString);    
            //                }
            //                else if (splitString.Length ==5)
            //                {
            //                    var validString = splitString[2].Substring(">");
            //                    sites.Add(validString);    
            //                }
            //                else
            //                {
            //                    var validString = resultText.Substring("/>", "<");
            //                    sites.Add(validString);    
            //                }

            //            }
            //            catch
            //            {
            //                sites.Add(resultText);
            //            }

            //        }

            //        if (sites.Any())
            //        {
            //            break;
            //        }
            //        else
            //        {
            //            searchDate = searchDate.AddDays(1);
            //        }
            //    }
            //    return sites;

            //}
            //catch (Exception ex)
            //{
            //    Util.ErrorLog(MethodBase.GetCurrentMethod(), ex, "에러");
            //}
            //return null;
        }

        /// <summary>
        /// 사이트 정보 가져오기
        /// </summary>
        /// <param name="date"></param>
        /// <param name="idx"></param>
        /// <param name="groupIdx"></param>
        /// <returns></returns>
        public static Tuple<int, int> GetSiteReservationInfo(DateTime date, int idx, int groupIdx)
        {
            var httpWRequest =
                (HttpWebRequest)
                    WebRequest.Create(
                        string.Format(
                            "http://www.campingsearch.co.kr/campReserve/ClassIfrm.asp?roomgroup_idx={0}&camp_idx={1}&ddate={2}&cnt=9 ",
                            groupIdx, idx, date.ToString("yyyy-MM-dd")));
            httpWRequest.UserAgent = "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.1; WOW64; Trident/6.0)";
            httpWRequest.KeepAlive = true;
            httpWRequest.Method = "Get";
            httpWRequest.Referer =
                string.Format(" http://www.campingsearch.co.kr/campReserve/reserveTableInfo.asp?idx={0}", idx);

            var theResponse = (HttpWebResponse)httpWRequest.GetResponse();
            var sr = new StreamReader(theResponse.GetResponseStream(), Encoding.GetEncoding("euc-kr"));

            var resultHtml = sr.ReadToEnd();

            resultHtml =
                resultHtml.Substring(
                    "<table border=\"0\" cellspacing=\"0\"  valign=\"top\" width=\"325\" align=\"left\"><tbody>",
                    "</tbody");


            var splitString = resultHtml.Substring("name=\"select2", "</select>").Split('<');
            var people = splitString[splitString.Length - 2].Substring("\">").Replace("명","");

            splitString = resultHtml.Substring("toAjax3(parent.InDate", "</select>").Split('<');
            string stayDay = "0";
            if (splitString.Length != 1)
            {
                stayDay = splitString[splitString.Length - 2].Substring("\">").Replace("박", "");
            }


            return new Tuple<int, int>(int.Parse(people), int.Parse(stayDay));
        }

        /// <summary>
        /// 사이트 정보 가져오기
        /// </summary>
        /// <param name="date"></param>
        /// <param name="idx"></param>
        /// <param name="groupIdx"></param>
        /// <returns></returns>
        public static IEnumerable<string> GetSitesNumber(DateTime date, int idx, int groupIdx)
        {
            var httpWRequest =
                (HttpWebRequest)
                    WebRequest.Create(
                        string.Format(
                            "http://www.campingsearch.co.kr/campReserve/ClassIfrm.asp?roomgroup_idx={0}&camp_idx={1}&ddate={2}&cnt=9 ",
                            groupIdx, idx, date.ToString("yyyy-MM-dd")));
            httpWRequest.UserAgent = "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.1; WOW64; Trident/6.0)";
            httpWRequest.KeepAlive = true;
            httpWRequest.Method = "Get";
            httpWRequest.Referer =
                string.Format(" http://www.campingsearch.co.kr/campReserve/reserveTableInfo.asp?idx={0}", idx);

            var theResponse = (HttpWebResponse)httpWRequest.GetResponse();
            var sr = new StreamReader(theResponse.GetResponseStream(), Encoding.GetEncoding("euc-kr"));

            var resultHtml = sr.ReadToEnd();

            resultHtml =
                resultHtml.Substring(
                    "<table border=\"0\" cellspacing=\"0\"  valign=\"top\" width=\"325\" align=\"left\"><tbody>",
                    "</tbody");
            var sites = new List<string>();

            int startIndex = 0;
            string startText = "<input type=\"checkbox\" onclick=\"checkbg(this.id,";
            string endText = ";\"";

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

                var splitString = resultText.Split(',');

                sites.Add(splitString[4] + "|" + splitString[2].Replace("'", ""));
            }
            return sites;
        }

        /// <summary>
        /// 해당 사이트 예약 가능 여부
        /// </summary>
        /// <param name="date"></param>
        /// <param name="idx"></param>
        /// <param name="site"></param>
        /// <returns></returns>
        public static string PossibleReservation(DateTime date, int idx, string site)
        {
            try
            {


                var httpWRequest =
                    (HttpWebRequest)
                        WebRequest.Create(
                            string.Format(
                                "http://www.campingsearch.co.kr/campReserve/reserveTableStatus.asp?c_year={0}&c_month={1}&idx={2}",
                                date.Year, date.Month, idx));
                httpWRequest.UserAgent = "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.1; WOW64; Trident/6.0)";
                httpWRequest.KeepAlive = true;
                httpWRequest.Method = "Get";
                httpWRequest.Referer =
                    string.Format(
                        "http://www.campingsearch.co.kr/campReserve/reserveTableStatus.asp?c_year={0}&c_month={1}&idx={2}",
                        date.Year, date.Month, idx);

                var theResponse = (HttpWebResponse) httpWRequest.GetResponse();
                var sr = new StreamReader(theResponse.GetResponseStream(), Encoding.GetEncoding("euc-kr"));

                var resultHtml = sr.ReadToEnd();

                if (resultHtml.IndexOf(string.Format("num11><b>{0}", date.Day)) == -1)
                {
                    return "";
                }

                resultHtml = resultHtml.Substring(string.Format("num11><b>{0}", date.Day), "</table>");

                int startIndex = 0;
                string startText = "<td>";
                string endText = "</td>";

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

                    if (resultText.Contains(site) && resultText.Contains("images/pop_reservation_icon7.gif"))
                    {
                        return resultText;
                    }
                }

            }
            catch (Exception)
            {
                
            }
            return "";
        }

        /// <summary>
        /// 예약가능 룸수
        /// </summary>
        /// <param name="date"></param>
        /// <param name="idx"></param>
        /// <param name="groupIdx"></param>
        /// <returns></returns>
        public static int GetFreeRoomCount(DateTime date, int idx, int groupIdx)
        {
            var httpWRequest =
                (HttpWebRequest)
                    WebRequest.Create(
                        string.Format(
                            "http://www.campingsearch.co.kr/campReserve/groupIfrm.asp?idx={0}&ddate={1}&selType={2}",
                            idx, date.ToString("yyyy-MM-dd"),groupIdx));
            httpWRequest.UserAgent = "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.1; WOW64; Trident/6.0)";
            httpWRequest.KeepAlive = true;
            httpWRequest.Method = "Get";
            httpWRequest.Referer =
                string.Format(
                    "http://www.campingsearch.co.kr/campReserve/reserveTableStatus.asp?c_year={0}&c_month={1}&idx={2}",
                    date.Year, date.Month, idx);

            var theResponse = (HttpWebResponse)httpWRequest.GetResponse();
            var sr = new StreamReader(theResponse.GetResponseStream(), Encoding.GetEncoding("euc-kr"));

            var resultHtml = sr.ReadToEnd();


            resultHtml = resultHtml.Substring("parent.ClassChk(" + groupIdx, ");");
            return int.Parse(resultHtml.Split(',')[3]);
        }

        /// <summary>
        /// 해당 사이트 예약 가능 여부
        /// </summary>
        /// <param name="date"></param>
        /// <param name="idx"></param>
        /// <param name="groupIdx"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static string GetDidx(DateTime date, int idx, int groupIdx, int count)
        {
            var httpWRequest =
                (HttpWebRequest)
                    WebRequest.Create(
                        string.Format(
                            "http://www.campingsearch.co.kr/campReserve/ClassIfrm.asp?roomgroup_idx={0}&camp_idx={1}&ddate={2}&cnt={3}",
                            groupIdx, idx, date.ToString("yyyy-MM-dd"), count));
            httpWRequest.UserAgent = "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.1; WOW64; Trident/6.0)";
            httpWRequest.KeepAlive = true;
            httpWRequest.Method = "Get";
            httpWRequest.Referer =
                string.Format(
                    "http://www.campingsearch.co.kr/campReserve/reserveTableStatus.asp?idx={0}&selectDate={1}&selectType={2}&x=1",
                    idx, date.ToString("yyyy-MM-dd"), groupIdx);

            var theResponse = (HttpWebResponse)httpWRequest.GetResponse();
            var sr = new StreamReader(theResponse.GetResponseStream(), Encoding.GetEncoding("euc-kr"));

            var resultHtml = sr.ReadToEnd();


            resultHtml = resultHtml.Substring("onclick=\"checkbg(this.id", ";");
            return resultHtml.Split(',')[5].Replace("\"","");
        }

        /// <summary>
        /// 비용
        /// </summary>
        /// <param name="date"></param>
        /// <param name="ddix"></param>
        /// <param name="groupIdx"></param>
        /// <returns></returns>
        public static string GetCost(DateTime date, int ddix, int groupIdx)
        {
            var httpWRequest =
                (HttpWebRequest)
                    WebRequest.Create(
                        string.Format(
                            "http://www.campingsearch.co.kr/campReserve/roomdaytotal_ajax.asp?date={2}&ridx={0}&didx={1}&v=1",
                            groupIdx, ddix, date.ToString("yyyy-MM-dd")));
            httpWRequest.UserAgent = "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.1; WOW64; Trident/6.0)";
            httpWRequest.KeepAlive = true;
            httpWRequest.Method = "Get";
            var theResponse = (HttpWebResponse)httpWRequest.GetResponse();
            var sr = new StreamReader(theResponse.GetResponseStream(), Encoding.GetEncoding("euc-kr"));

            return sr.ReadToEnd();
        }

        /// <summary>
        /// 예약하기
        /// </summary>
        /// <param name="people"></param>
        /// <param name="site"></param>
        /// <returns></returns>
        public static string DoReservation(People people, CampSite site)
        {
            try
            {

                var dayParameter = "";
                for (var i = 0; i < site.StayDay; i++)
                {
                    dayParameter =
                        string.Format(
                            "r1{0}={1}&rr{0}={2}&rr1{0}={3}&rTo{0}=0&b{0}=2&m{0}=&rdidx{0}={4}&cnt{0}=&rr2{0}={5}&date{0}={6}&dateEnd{0}={7}&dc_cost{0}={8}&base_cost{0}={9}&people_cost{0}=5000",
                            i, 
                            HttpUtility.UrlEncode(site.SiteName, Encoding.GetEncoding("euc-kr")), 
                            HttpUtility.UrlEncode(site.SiteNumberName, Encoding.GetEncoding("euc-kr")), 
                            site.TotalCost, 
                            site.SiteNumber, 
                            site.Cost,
                            site.StartDate.ToString("yyyy-MM-dd"), 
                            site.StartDate.AddDays(site.StayDay).ToString("yyyy-MM-dd"), 
                            i == 0 ? 0 : site.DcCost, site.Cost
                            );
                }

                string parameter =
                    string.Format(
                        "campidx={0}&classnum={1}&ddate={2}&ri=1&gidx={3}&roomCount={4}&roomChk=0&roomCnt=1&{5}&roomtotal={6}&count={7}&oi=0&optCount=0&optChk=&optCnt=0&optiontotal=0&agree=on&name={8}&hp1={9}&hp2={10}&hp3={11}&email1={12}&email2={13}&user_car_num={14}&send_message=&pay_type=%B9%AB%C5%EB%C0%E5&bankinfo=%5B%BF%EC%B8%AE%5D+1002-635-646857+%28%BF%B9%B1%DD%C1%D6%3A%C3%A4%C8%F1%BD%C2%29&gopaymethod=&goodname=%BC%B1%C0%CE%C0%E5&buyername=%C8%AB%B1%E6%B5%BF&buyeremail=hkd%40abcd.com&buyertel=010-1234-5678&acceptmethod=SKIN%28ORIGINAL%29%3AHPP%281%29&oid=Merchant_Order_ID&INIregno=&ini_encfield=&ini_certid=&quotainterest=&paymethod=&cardcode=&cardquota=&rbankcode=&reqsign=DONE&encrypted=&sessionkey=&uid=&sid=&version=4000&clickcontrol=enable",
                        site.Idx,
                        site.Classnum,
                        site.StartDate.ToString("yyyy-MM-dd"),
                        site.GroupIdx,
                        site.RoomCount,
                        dayParameter,
                        site.TotalCost,
                        site.StayDay,
                        HttpUtility.UrlEncode(people.Name, Encoding.GetEncoding("euc-kr")), 
                        people.CellPhone1,
                        people.CellPhone2,
                        people.CellPhone3,
                        people.Email1,
                        people.Email2,
                        people.CarNumber);

                var httpWRequest =
                    (HttpWebRequest)
                        WebRequest.Create("http://www.campingsearch.co.kr/campReserve/reserveTableInfo_act.asp");
                httpWRequest.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
                httpWRequest.Headers.Add("Accept-Encoding", "gzip,deflate,sdch");
                httpWRequest.Headers.Add("Accept-Language", "en,en-US;q=0.8,ko;q=0.6");
                httpWRequest.Headers.Add("Origin", "http://www.campingsearch.co.kr");
                httpWRequest.Referer =
                    "http://www.campingsearch.co.kr/campReserve/reserveTableInfo_1.asp?optiontotal=0&roomtotal=40%2C000%BF%F8&oi=0&gidx=175&campidx=362&ri=1&ddate=2014-07-22&roomCount=15&roomChk=0&roomCnt=1&optCount=0&optChk=&optCnt=0&classnum=N&r10=%C4%B7%C7%CE%281%B9%DA%7E3%B9%DA%29&rr0=%C4%B7%C7%CE%281%B9%DA%7E3%B9%DA%29&rr10=40000&rTo0=0&b0=1&m0=&rdidx0=309&cnt0=&rr20=40000";
                httpWRequest.UserAgent = "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.1; WOW64; Trident/6.0)";
                httpWRequest.ContentType = "application/x-www-form-urlencoded";
                httpWRequest.KeepAlive = true;
                httpWRequest.Method = "Post";
                httpWRequest.ContentLength = Encoding.GetEncoding("euc-kr").GetBytes(parameter).Length;

                var sw = new StreamWriter(httpWRequest.GetRequestStream(), Encoding.GetEncoding("euc-kr"));
                sw.Write(parameter);
                sw.Close();

                var theResponse = (HttpWebResponse) httpWRequest.GetResponse();
                var sr = new StreamReader(theResponse.GetResponseStream(), Encoding.GetEncoding("euc-kr"));

                string resultHtml = sr.ReadToEnd();
                return resultHtml;
            }
            catch (Exception ex)
            {
                Util.ErrorLog(MethodBase.GetCurrentMethod(), ex, "에러");
                return null;
            }
        }

        /// <summary>
        ///  로그
        /// </summary>
        /// <param name="date"></param>
        /// <param name="idx"></param>
        /// <returns></returns>
        public static void WebLog(DateTime date, int idx )
        {
            try
            {
                var httpWRequest =
                    (HttpWebRequest)
                        WebRequest.Create(
                            string.Format("http://gunmoni.weblog.cafe24.com/weblog.html?uid=gunmoni&udim=1920*1080&uref=http://www.campingsearch.co.kr/campReserve/reserveTableStatus.asp?c_year={0}&c_month={1}&idx={2}&uname=캠핑서치&url=http://www.campingsearch.co.kr/campReserve/reserveTableStatus.asp?c_year={0}&c_month={1}&idx={2}",
                            date.Year,
                            date.Month,
                            idx)
                            );
                httpWRequest.Accept = "*/*";
                httpWRequest.Headers.Add("Accept-Language", "en,en-US;q=0.8,ko;q=0.6");
                httpWRequest.Headers.Add("Accept-Encoding", "gzip,deflate,sdch");
                httpWRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/35.0.1916.153 Safari/537.36";
                httpWRequest.Referer =
                    string.Format(
                        "http://www.campingsearch.co.kr/campReserve/reserveTableStatus.asp?c_year={0}&c_month={1}&idx={2}",
                        date.Year,
                        date.Month,
                        idx);
                
                var theResponse = (HttpWebResponse) httpWRequest.GetResponse();
                var sr = new StreamReader(theResponse.GetResponseStream());

                sr.ReadToEnd();
            }
            catch (Exception ex)
            {
                Util.ErrorLog(MethodBase.GetCurrentMethod(), ex, "에러");
            }
        }

        /// <summary>
        /// sms 보내기
        /// </summary>
        /// <param name="cTranmsg"></param>
        /// <returns></returns>
        public static void SendSms(string cTranmsg)
        {
            //string.Format("http://www.campingsearch.co.kr/sms/smsSend.asp?cTranmsg=[중바위캠핑장]2014-07-10 예약신청.6시간안에 미입금시 자동취소됩니다.&cTranphone=01082267979&cTrancallback=01032530618",
            try
            {
                var httpWRequest =
                    (HttpWebRequest)
                        WebRequest.Create(
                            string.Format("http://www.campingsearch.co.kr/{0}",
                            cTranmsg
                            ));
                httpWRequest.Accept = "*/*";
                httpWRequest.Headers.Add("Accept-Language", "en,en-US;q=0.8,ko;q=0.6");
                httpWRequest.Headers.Add("Accept-Encoding", "gzip,deflate,sdch");
                httpWRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/35.0.1916.153 Safari/537.36";
                httpWRequest.Referer = "http://www.campingsearch.co.kr/campReserve/reserveTableInfo_act.asp";

                var theResponse = (HttpWebResponse)httpWRequest.GetResponse();
                var sr = new StreamReader(theResponse.GetResponseStream());

                sr.ReadToEnd();
            }
            catch (Exception ex)
            {
                Util.ErrorLog(MethodBase.GetCurrentMethod(), ex, "에러");
            }
        }

        /// <summary>
        ///  로그
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public static void Event(int idx)
        {
            try
            {
                var httpWRequest =
                    (HttpWebRequest)
                        WebRequest.Create("http://campingsearch.co.kr/access.asp?page=reserve_status&click_event=access&condition=reservestatus_access");
                httpWRequest.Accept = "*/*";
                httpWRequest.Headers.Add("Accept-Language", "en,en-US;q=0.8,ko;q=0.6");
                httpWRequest.Headers.Add("Accept-Encoding", "gzip,deflate,sdch");
                httpWRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/35.0.1916.153 Safari/537.36";
                httpWRequest.Referer ="http://www.campingsearch.co.kr/campReserve/reserveTableStatus.asp?idx=" + idx;

                var theResponse = (HttpWebResponse)httpWRequest.GetResponse();
                var sr = new StreamReader(theResponse.GetResponseStream());

                sr.ReadToEnd();
            }
            catch (Exception ex)
            {
                Util.ErrorLog(MethodBase.GetCurrentMethod(), ex, "에러");
            }
        }
    }
}