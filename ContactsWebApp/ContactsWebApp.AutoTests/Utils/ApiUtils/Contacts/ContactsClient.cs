using ContactsWebApp.AutoTests.Contacts.Data;
using ContactsWebApp.AutoTests.Tasks.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace ContactsWebApp.AutoTests.Utils.ApiUtils.Contacts
{
    public static class ContactsClient
    {
        private static ApiClient client => ApiClient.Instance;

        public static void CloseConnection()
        {
            client.CloseConnection();
        }

        public static List<Contact> GetContacts()
        {
            var response = client.Get(Configuration.ApiUrl + ContactsMethods.AllContacts).GetContent();
            return JsonConvert.DeserializeObject<List<Contact>>(response);
        }

        public static Contact GetContact(int id)
        {
            var response = client.Get(Configuration.ApiUrl + ContactsMethods.Contact(id)).GetContent();
            return JsonConvert.DeserializeObject<Contact>(response);
        }

        public static Contact DeleteContact(int id)
        {
            var response = client.Delete(Configuration.ApiUrl + ContactsMethods.Contact(id)).GetContent();
            return JsonConvert.DeserializeObject<Contact>(response);
        }

        public static Contact AddContact(Contact contact)
        {
            var response = client.Post(
                $"{Configuration.ApiUrl}{ContactsMethods.AllContacts}",
                JsonConvert.SerializeObject(contact)
                );
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            var text = response.GetContent();
            return JsonConvert.DeserializeObject<Contact>(text);
        }

        public static Contact EditContact(int id, Contact editedContact)
        {
            var response = client.Put(
                $"{Configuration.ApiUrl}{ContactsMethods.Contact(id)}", 
                JsonConvert.SerializeObject(editedContact));
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            var text = response.GetContent();
            return JsonConvert.DeserializeObject<Contact>(text);
        }
    }
}
