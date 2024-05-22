using Microsoft.Extensions.Configuration;

namespace Movie.Persistance;

static class Configuration
{
    static public string ConnectionString
    {
        get
        {
            ConfigurationManager configurationManager = new();
            configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(),
                "../../Presentation/Movie.API"));
            configurationManager.AddJsonFile("appsettings.json");
            return configurationManager.GetConnectionString("MSSQL");
        }
    }
}