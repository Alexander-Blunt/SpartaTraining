using System.Configuration;

namespace APIClientApp;

public static class AppConfigReader
{
    public static readonly string BaseUrl = ConfigurationManager.AppSettings["BaseUrl"];
}