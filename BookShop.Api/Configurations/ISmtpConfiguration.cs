namespace BookShop.Api.Configurations
{
    public interface ISmtpConfiguration
    {
        string Server { get; set; }
        string User { get; set; }
        string Pass { get; set; }
        int Port { get; set; }
    }
}