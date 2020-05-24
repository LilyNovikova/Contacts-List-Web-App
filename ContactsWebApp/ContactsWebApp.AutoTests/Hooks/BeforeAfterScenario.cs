using Aquality.Selenium.Browsers;
using ContactsWebApp.AutoTests.Contacts.Data;
using ContactsWebApp.AutoTests.Steps;
using ContactsWebApp.AutoTests.Tasks.Models;
using ContactsWebApp.AutoTests.Utils.ApiUtils;
using TechTalk.SpecFlow;
using Client = ContactsWebApp.AutoTests.Utils.ApiUtils.Contacts.ContactsClient;

namespace ContactsWebApp.AutoTests.Hooks
{
    [Binding]
    public class BeforeAfterScenario : BaseSteps
    {
        private readonly ScenarioContext context;

        public BeforeAfterScenario(ScenarioContext context)
        {
            this.context = context;
        }

        [BeforeScenario]
        public void SetUp()
        {
            StepNumber = 1;
            Browser.Maximize();
            Browser.GoTo(Configuration.BaseUrl);
        }

        [AfterScenario]
        public void TearDown()
        {
            AddScreenshot();
            AqualityServices.Browser.Quit();
        }

        [AfterScenario("needsDelete", Order = 1)]
        public void DeleteContact()
        {
            var contact = context.Get<Contact>();
            Client.DeleteContact(contact.ID);
        }

        [AfterScenario("api", Order = 2)]
        public void TearDownAPI()
        {
            ApiClient.Instance.CloseConnection();
        }

    }
}
