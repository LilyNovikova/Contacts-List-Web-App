using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using ContactsWebApp.AutoTests.Contacts.Data;
using ContactsWebApp.AutoTests.Contacts.Forms;
using NUnit.Framework;

namespace ContactsWebApp.AutoTests.Steps
{
    [Binding]
    public class DeleteFormSteps : BaseSteps
    {
        private readonly ScenarioContext context;

        public DeleteFormSteps(ScenarioContext context)
        {
            this.context = context;
        }

        [When(@"I click Delete button on Delete Form")]
        public void WhenIClickDeleteButtonOnDeleteForm()
        {
            DeleteForm.Delete();
        }

        [Then(@"'(.*)' data is displayed on Delete Form")]
        public void ThenDataIsDisplayedOnDeleteForm(string contact)
        {
            var contactToDelete = TestData.Contact(contact);
            Assert.AreEqual(contactToDelete, DeleteForm.Contact, "Wrong contact");
        }


        [Then(@"Delete Form is displayed")]
        public void ThenDeleteFormIsDisplayed()
        {
            Assert.IsTrue(DeleteForm.IsDisplayed, "Delete form is not displayed");
        }
    }
}
