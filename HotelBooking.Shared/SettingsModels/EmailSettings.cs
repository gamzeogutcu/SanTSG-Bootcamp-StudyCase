namespace HotelBooking.Shared.SettingsModels
{//a model that will hold the details from the appsettings.json File.
    public class EmailSettings
    {
        public string Mail { get; set; }
        public string DisplayName { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
    }
}
