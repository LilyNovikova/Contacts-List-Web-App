using System;
using TechTalk.SpecFlow;
using ContactsWebApp.AutoTests.Contacts.Data;
using ContactsWebApp.AutoTests.Contacts.Forms;
using ContactsWebApp.AutoTests.Utils.ApiUtils;
using ContactsWebApp.AutoTests.Utils.ApiUtils.Contacts;
using Client = ContactsWebApp.AutoTests.Utils.ApiUtils.Contacts.ContactsClient;
using NUnit.Framework;

namespace ContactsWebApp.AutoTests.Steps
{
    [Binding]
    public class ApiSteps : BaseSteps
    {
        private readonly ScenarioContext context;

        public ApiSteps(ScenarioContext context)
        {
            this.context = context;
        }

        [When(@"I delete '(.*)' through API")]
        public void WhenIDeleteThroughAPI(string contact)
        {
            var contactToDelete = TestData.Contact(contact);
            var id = ContactsForm.GetContactID(contactToDelete);
            Client.DeleteContact(id);
        }

        [When(@"I add '(.*)' through API")]
        public void WhenIAddThroughAPI(string contact)
        {
            var contactToAdd = TestData.Contact(contact);
            var newContact = Client.AddContact(contactToAdd);
            context.Set(newContact);
        }

        [When(@"I edit '(.*)' as '(.*)' through API")]
        public void WhenIEditAsThroughAPI(string contact, string editedContact)
        {
            var first = TestData.Contact(contact);
            var second = TestData.Contact(editedContact);
            var id = ContactsForm.GetContactID(first);
            var newContact = Client.EditContact(id, second);
            context.Set(newContact);
        }

        [Then(@"Contacts list from API contains '(.*)'")]
        public void ThenContactsListFromAPIContains(string contact)
        {
            var contacts = Client.GetContacts();
            var contactFromTestData = TestData.Contact(contact);
            CollectionAssert.Contains(contacts, contactFromTestData, "List doesn't contain contact");
        }

    }
}
