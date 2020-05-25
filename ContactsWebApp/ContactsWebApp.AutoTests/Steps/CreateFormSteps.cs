using ContactsWebApp.AutoTests.Contacts.Data;
using ContactsWebApp.AutoTests.Contacts.Forms;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace ContactsWebApp.AutoTests.Steps
{
    [Binding]
    public class CreateFormSteps : BaseSteps
    {
        private readonly ScenarioContext context;

        public CreateFormSteps(ScenarioContext context)
        {
            this.context = context;
        }

        [When(@"I fill fields with '(.*)' data on Create Form")]
        public void WhenIFillFieldsWithDataOnCreateForm(string contact)
        {
            var contactToCreate = TestData.Contact(contact);
            CreateForm.FillFields(contactToCreate);
        }

        [When(@"I click Create button on Create Form")]
        public void WhenIClickCreateButtonOnCreateForm()
        {
            CreateForm.Create();
        }

        [Then(@"Create Form is displayed")]
        public void ThenCreateFormIsDisplayed()
        {
            Assert.IsTrue(CreateForm.IsDisplayed, "Create form is not displayed");
        }
    }
}
