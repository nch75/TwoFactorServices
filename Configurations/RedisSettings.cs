namespace TwoFactorService.Configurations
{
    public class RedisSettings
    {
        public RedisSettings(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public string ConnectionString { get; set; }
    }
}
