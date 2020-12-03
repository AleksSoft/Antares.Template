namespace ServiceName.Common.Configuration
{
    public class AppConfig
    {
        public SwisschainProductNameServiceNameSettings SwisschainProductNameServiceName { get; set; }
    }

    public class SwisschainProductNameServiceNameSettings
    {
        public DbConfig Db { get; set; }
    }
}
