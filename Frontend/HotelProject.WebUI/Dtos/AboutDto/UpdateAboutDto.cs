namespace HotelProject.WebUI.Dtos.AboutDto
{
    public class UpdateAboutDto
    {
        // about güncellenebilir ancak silinemez istiyoruz
        public int AboutUsId { get; set; }
        public string Title1 { get; set; }
        public string Title2 { get; set; }
        public string Contentt { get; set; }
        public int CustomerCount { get; set; }
        public int RoomCount { get; set; }
        public int StaffCount { get; set; }
    }
}
