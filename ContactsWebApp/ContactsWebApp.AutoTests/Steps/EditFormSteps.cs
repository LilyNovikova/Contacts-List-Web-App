using ContactsWebApp.AutoTests.Contacts.Data;
using ContactsWebApp.AutoTests.Contacts.Forms;
using ContactsWebApp.AutoTests.Tasks.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace ContactsWebApp.AutoTests.Steps
{
    [Binding]
    public class EditFormSteps : BaseSteps
    {
        private readonly ScenarioContext context;

        public EditFormSteps(ScenarioContext context)
        {
            this.context = context;
        }

        [When(@"I fill fields with '(.*)' data on Edit Form")]
        public void WhenIFillFieldsWithDataOnEditForm(string contact)
        {
            var editedContact = TestData.Contact(contact);
            EditForm.FillFields(editedContact);
        }

        [When(@"I click Save button on Edit Form")]
        public void WhenIClickSaveButtonOnEditForm()
        {
            EditForm.Save();
        }


        [Then(@"Edit Form is displayed")]
        public void ThenEditFormIsDisplayed()
        {
            Assert.IsTrue(EditForm.IsDisplayed, "Edit form is not displayed");
        }
    }
}
