using Aquality.Selenium.Core.Utilities;

namespace ContactsWebApp.AutoTests.Contacts.Data
{
    public static class Configuration
    {
        private static JsonSettingsFile jsonConfigurationFile => new JsonSettingsFile("config.json");

        public static string BaseUrl => jsonConfigurationFile.GetValue<string>(".webUrl");
        public static string ApiUrl => jsonConfigurationFile.GetValue<string>(".apiUrl");
    }
}
