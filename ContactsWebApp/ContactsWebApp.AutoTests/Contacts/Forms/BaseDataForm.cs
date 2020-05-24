using Aquality.Selenium.Elements.Interfaces;
using ContactsWebApp.AutoTests.Tasks.Models;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactsWebApp.AutoTests.Contacts.Forms
{
    public class BaseDataForm : BaseForm
    {
        private ITextBox nameTxt => ElementFactory.GetTextBox(By.Id("Name"), "Name");
        private ITextBox commentTxt => ElementFactory.GetTextBox(By.Id("Comment"), "Comment");
        private ITextBox cellTxt => ElementFactory.GetTextBox(By.Id("Cell"), "Cell");
        private IComboBox groupTxt => ElementFactory.GetComboBox(By.Id("Group"), "Group");

        protected BaseDataForm(By locator, string name) : base(locator, name)
        {
        }

        public void FillFields(Contact contact)
        {
            nameTxt.ClearAndType(contact.Name);
            commentTxt.ClearAndType(contact.Comment);
            cellTxt.ClearAndType(contact.Cell);
            groupTxt.SendKeys(contact.Group);
        }
    }
}
