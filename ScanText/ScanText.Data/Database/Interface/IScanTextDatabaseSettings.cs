namespace ScanText.Infra.Configuration.DataBase.Interface
{
    public interface IScanTextDatabaseSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
