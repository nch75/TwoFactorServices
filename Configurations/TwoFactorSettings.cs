namespace TwoFactorService.Configurations
{
    public class TwoFactorSettings
    {
        public int CodeLifetime { get; set; } // in minutes
        public int MaxConcurrentCodes { get; set; }
    }
}
