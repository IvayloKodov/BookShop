namespace BookShop.Api.Configurations
{
    public class SmtpConfiguration : ISmtpConfiguration
    {
        public string Server { get; set; }

        public string User { get; set; }

        public string Pass { get; set; }

        public int Port { get; set; }
    }
}
