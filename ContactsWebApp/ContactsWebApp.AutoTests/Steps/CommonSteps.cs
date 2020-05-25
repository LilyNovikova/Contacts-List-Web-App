using System;
using TechTalk.SpecFlow;
using ContactsWebApp.AutoTests.Contacts.Data;
using ContactsWebApp.AutoTests.Contacts.Forms;

namespace ContactsWebApp.AutoTests.Steps
{
    [Binding]
    public class CommonSteps : BaseSteps
    {
        private readonly ScenarioContext context;

        public CommonSteps(ScenarioContext context)
        {
            this.context = context;
        }

        [Given(@"I have added '(.*)' to Contacts List")]
        public void GivenIHaveAddedToContactsList(string contact)
        {
            var contactToCreate = TestData.Contact(contact);
            ContactsForm.AddNew();
            CreateForm.FillFields(contactToCreate);
            CreateForm.Create();
        }

        [When(@"I refresh the page")]
        public void WhenIRefreshThePage()
        {
            Browser.Refresh();
        }
    }
}
