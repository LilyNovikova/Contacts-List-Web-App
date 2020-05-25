using Aquality.Selenium.Core.Logging;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace ContactsWebApp.AutoTests.Contacts.Forms
{
    public abstract class BaseForm : Form
    {
        protected BaseForm(By locator, string name) : base(locator, name)
        {
        }

        protected new Logger Logger => Aquality.Selenium.Browsers.AqualityServices.Logger;

    }
}
