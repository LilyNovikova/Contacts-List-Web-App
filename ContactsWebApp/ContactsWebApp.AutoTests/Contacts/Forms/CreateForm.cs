using Aquality.Selenium.Elements.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactsWebApp.AutoTests.Contacts.Forms
{
    public class CreateForm : BaseDataForm
    {
        private IButton createBtn => ElementFactory.GetButton(By.Id("btnCreate"), "Create");
        public CreateForm() : base(By.Id("CreateContact"), "CreateForm")
        {
        }

        public void Create() => createBtn.Click();
    }
}
