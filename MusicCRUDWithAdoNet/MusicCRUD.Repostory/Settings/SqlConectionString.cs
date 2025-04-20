namespace MusicCRUD.Repostory.Settings;


public class SqlConectionString
{
    private string connectionString;

    public string ConnectionString
    {
        get { return connectionString; }
        set { connectionString = value; }

    }
    public SqlConectionString(string connectionString)
    {
        ConnectionString = connectionString;
    }
}
