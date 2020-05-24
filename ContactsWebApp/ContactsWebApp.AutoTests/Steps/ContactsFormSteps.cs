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
    public class ContactsFormSteps : BaseSteps
    {
        private readonly ScenarioContext context;

        public ContactsFormSteps(ScenarioContext context)
        {
            this.context = context;
        }

        [When(@"I click '(.*)' '(.*)' button on Contacts Form")]
        public void WhenIClickButtonOnContactsForm(string contact, string button)
        {
            var contactFromTestData = TestData.Contact(contact);
            var id = ContactsForm.GetContactID(contactFromTestData);
            switch (button)
            {
                case "Delete":
                    ContactsForm.Delete(id);
                    break;
                case "Edit":
                    ContactsForm.Edit(id);
                    break;
            }
        }

        [When(@"I click Add New Contact button on Contacts Form")]
        public void WhenIClickButtonOnContactsForm()
        {
            ContactsForm.AddNew();
        }

        [Then(@"'(.*)' is displayed on Contacts Form")]
        public void ThenIsDisplayedOnContactsForm(string contact)
        {
            var contactFromTestData = TestData.Contact(contact);
            CollectionAssert.Contains(ContactsForm.Contacts, contactFromTestData, "Contact is not displayed");
            contactFromTestData.ID = ContactsForm.GetContactID(contactFromTestData);
            context.Set(contactFromTestData);
        }

        [Then(@"Contacts Form is displayed")]
        public void ThenContactsFormIsDisplayed()
        {
            Assert.IsTrue(ContactsForm.IsDisplayed, "Contacts form is not displayed");
        }

        [Then(@"'(.*)' is not displayed on Contacts Form")]
        public void ThenIsNotDisplayedOnContactsForm(string contact)
        {
            var contactFromTestData = TestData.Contact(contact);
            CollectionAssert.DoesNotContain(ContactsForm.Contacts, contactFromTestData, "Contact is displayed");
        }
    }

}
