using Aquality.Selenium.Core.Utilities;
using ContactsWebApp.AutoTests.Tasks.Models;

namespace ContactsWebApp.AutoTests.Contacts.Data
{
    public static class TestData
    {
        private static string contactsPath => "contacts.json";

        private static JsonSettingsFile contactsFile => new JsonSettingsFile(contactsPath);

        public static Contact Contact(string name) => contactsFile.GetValue<Contact>($".{name}");

    }
}
