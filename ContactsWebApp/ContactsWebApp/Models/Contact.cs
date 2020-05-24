using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;

namespace ContactsWebApp.Models
{
    public class Contact
    {
        [JsonProperty("id")]
        public int ID { get; set; }

        [JsonProperty("name")]
        [StringLength(50, MinimumLength = 3), Required]
        public string Name { get; set; }

        [JsonProperty("comment")]
        [StringLength(250)]
        public string Comment { get; set; }

        [JsonProperty("cell")]
        [StringLength(15, MinimumLength = 1), Required]
        public string Cell { get; set; } 

        [JsonProperty("group")]
        [Required]
        public string Group { get; set; } 

        [JsonIgnore]
        public SelectList GroupNames { get; } = new SelectList(
            new List<string> {
                "Unknown", "Family", "Friends", "Work", "Other"
            }
        );

        [JsonIgnore]
        public static List<string> Properties => 
            typeof(Contact).GetProperties()
            .Select(p => p.Name)
            .Where(name => name != nameof(GroupNames))
            .ToList();

        public void Update(Contact task)
        {
            this.Name = task.Name;
            this.Comment = task.Comment;
            this.Cell = task.Cell;
            this.Group = task.Group;
        }
    }
}
