namespace ScanText.Infra.Configuration.DataBase.Settings.Interfaces
{
    public interface IScanTextDatabaseSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
