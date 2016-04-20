namespace NaverCafe
{
    class CampSite
    {
        public int Idx { get; set; }
        public string CampName { get; set; }
        public int GroupIdx { get; set; }
        public string SiteName { get; set; }
        public int SiteNumber { get; set; }
        public string SiteNumberName { get; set; }
        public int StayDay { get; set; }
        public int PeopleCount { get; set; }
        public System.DateTime StartDate { get; set; }
        public int RoomCount { get; set; }
        public string Classnum { get; set; }
        public int Cost { get; set; }
        public int DcCost { get; set; }
        public int TotalCost
        {
            get
            {
                return  Cost * StayDay - (DcCost * (StayDay -1));
            }
        }
        
    }

    class People
    {
        public string Name { get; set; }
        public string CellPhone1 { get; set; }
        public string CellPhone2 { get; set; }
        public string CellPhone3 { get; set; }
        public string Email1 { get; set; }
        public string Email2 { get; set; }
        public int CarNumber { get; set; }
    }
}
