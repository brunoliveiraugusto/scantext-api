using ScanText.Infra.Configuration.DataBase.Settings.Interfaces;

namespace ScanText.Infra.Configuration.DataBase
{
    public class ScanTextDatabaseSettings : IScanTextDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
