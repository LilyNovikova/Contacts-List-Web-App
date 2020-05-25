using Newtonsoft.Json;
using ContactsWebApp.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ContactsWebApp.Data
{
    public class Storage
    {
        public const string FilePath = "JsonData\\storage.json";
        private static Storage storage;
        private static List<Contact> contacts;
        private static int initId;

        private Storage()
        {
            contacts = JsonConvert.DeserializeObject<List<Contact>>(File.ReadAllText(FilePath));
            var ids = contacts.Select(t => t.ID);
            initId = (ids.Count() == 0 ? -1 :  ids.Max()) + 1;
        }

        public static Storage Instance
        {
            get
            {
                if (storage == null)
                {
                    storage = new Storage();
                }
                return storage;
            }
        }

        public List<Contact> Contacts => contacts;

        public void Add(Contact task)
        {
            task.ID = initId;
            initId++;
            contacts.Add(task);
            Save();
        }

        public void Remove(Contact contact)
        {
            contacts = contacts.Where(c => c.ID != contact.ID).ToList();
            Save();
        }

        public Contact GetById(int id)
        {
            return Contacts.Where(c => c.ID == id).FirstOrDefault();
        }

        public void Edit(int id, Contact contactData)
        {
            contacts = contacts.Select(c =>
            {
                if (c.ID == id)
                {
                    c.Update(contactData);
                }
                return c;
            }).ToList();
            Save();
        }

        private void Save()
        {
            var json = JsonConvert.SerializeObject(contacts);
            File.WriteAllText(FilePath, json);
        }

        ~Storage()
        {
            Save();
        }
    }
}
