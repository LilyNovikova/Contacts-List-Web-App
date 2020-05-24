using Aquality.Selenium.Elements.Interfaces;
using ContactsWebApp.AutoTests.Tasks.Models;
using ContactsWebApp.Framework.Forms;
using Gherkin.Ast;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ContactsWebApp.AutoTests.Contacts.Forms
{
    public class ContactsForm : BaseForm
    {
        private Table contactsTable => new Table("//table[@id='ContactsTable']");
        private IButton addNewBtn => ElementFactory.GetButton(By.Id("btnCreateNew"), "Add new");

        public ContactsForm() : base(By.Id("ContactsTable"), "ContactsForm")
        {
        }

        public int ContactsNumber => contactsTable.GetColumn(1).Count();

        public List<Contact> Contacts
        {
            get
            {
                var contacts = new List<Contact>();
                for (var i = 1; i <= ContactsNumber; i++)
                {
                    contacts.Add(new Contact
                    {
                        ID = int.Parse(contactsTable[i, nameof(Contact.ID)].Text.Trim()),
                        Name = contactsTable[i, nameof(Contact.Name)].Text,
                        Comment = contactsTable[i, nameof(Contact.Comment)].Text,
                        Cell = contactsTable[i, nameof(Contact.Cell)].Text,
                        Group = contactsTable[i, nameof(Contact.Group)].Text,
                    });
                }
                return contacts;
            }
        }

        public int GetContactID(Contact contact)
        {
            var cFromList = Contacts.Where(c => c.Equals(contact)).FirstOrDefault();
            if(cFromList == null)
            {
                throw new ArgumentException($"No such contact in the table({contact})");
            }
            return cFromList.ID;
        }

        public void AddNew() => addNewBtn.Click();

        public void Edit(int id)
        {
            ElementFactory.GetButton(By.Id($"btnEdit_{id}"), $"Edit {id}").Click();
        }

        public void Delete(int id)
        {
            ElementFactory.GetButton(By.Id($"btnDelete_{id}"), $"Delete {id}").Click();
        }
    }
}
