using Aquality.Selenium.Elements.Interfaces;
using ContactsWebApp.AutoTests.Tasks.Models;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactsWebApp.AutoTests.Contacts.Forms
{
    public class DeleteForm : BaseForm
    {
        private IButton deleteBtn => ElementFactory.GetButton(By.Id("btnDelete"), "Delete");

        public DeleteForm() : base(By.Id("btnDelete"), "DeleteForm")
        {
        }

        public Contact Contact =>
            new Contact
            {
                ID = int.Parse(FieldValue(nameof(Contact.ID))),
                Name = FieldValue(nameof(Contact.Name)),
                Cell = FieldValue(nameof(Contact.Cell)),
                Comment = FieldValue(nameof(Contact.Comment)),
                Group = FieldValue(nameof(Contact.Group))
            };

        public void Delete() => deleteBtn.Click();

        private string FieldValue(string fieldName) => ElementFactory.GetLabel(By.Id(fieldName), fieldName).Text;
    }
}
