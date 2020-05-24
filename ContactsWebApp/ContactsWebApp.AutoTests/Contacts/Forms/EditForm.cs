using Aquality.Selenium.Elements.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactsWebApp.AutoTests.Contacts.Forms
{
    public class EditForm : BaseDataForm
    {
        private IButton saveBtn => ElementFactory.GetButton(By.Id("btnSave"), "Save");
        public EditForm() : base(By.Id("EditContact"), "EditForm")
        {
        }

        public void Save() => saveBtn.Click();
    }
}
