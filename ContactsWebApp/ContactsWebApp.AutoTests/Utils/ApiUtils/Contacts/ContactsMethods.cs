using System;
using System.Collections.Generic;
using System.Text;

namespace ContactsWebApp.AutoTests.Utils.ApiUtils.Contacts
{
    public static class ContactsMethods
    {
        public const string AllContacts = "Contacts";
        public static string Contact(int id) => $"Contacts/{id}";

    }
}
