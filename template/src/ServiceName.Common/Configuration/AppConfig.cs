namespace ServiceName.Common.Configuration
{
    public class AppConfig
    {
        public SwisschainProductNameServiceNameSettings SwisschainProductNameServiceNameSettings { get; set; }
    }

    public class SwisschainProductNameServiceNameSettings
    {
        public DbConfig Db { get; set; }
    }
}
