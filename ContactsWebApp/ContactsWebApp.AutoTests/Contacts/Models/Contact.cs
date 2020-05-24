using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ContactsWebApp.AutoTests.Tasks.Models
{
    public class Contact
    {
        [JsonProperty("id")]
        public int ID { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("comment")]
        public string Comment { get; set; }

        [JsonProperty("cell")]
        public string Cell { get; set; }

        [JsonProperty("group")]
        public string Group { get; set; }


        public override bool Equals(object obj)
        {
            var c = obj as Contact;
            if (c == null)
            {
                return false;
            }
            return Equals(c);
        }

        protected bool Equals(Contact contact)
        {
            return Name == contact.Name
                && Comment == contact.Comment
                && Cell == contact.Cell
                && Group == contact.Group;
        }

        public override string ToString()
        {
            return $"Contact:\n"
                + $"{nameof(ID)}: {ID}\n"
                + $"{nameof(Name)}: {Name}\n"
                + $"{nameof(Comment)}: {Comment}\n"
                + $"{nameof(Cell)}: {Cell}\n"
                + $"{nameof(Group)}: {Group}.\n";
        }

        [JsonIgnore]
        public static List<string> Properties => 
            typeof(Contact).GetProperties()
            .Select(p => p.Name)
            .ToList();
    }
}
