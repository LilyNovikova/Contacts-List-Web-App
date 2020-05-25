using Aquality.Selenium.Browsers;
using Aquality.Selenium.Core.Waitings;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ContactsWebApp.AutoTests.Contacts.Forms;

namespace ContactsWebApp.AutoTests.Steps
{
    public abstract class BaseSteps
    {
        protected int StepNumber;
        private const string TestResultsScreenshot = "test_results.png";
        protected Browser Browser => AqualityServices.Browser;


        protected ContactsForm ContactsForm => new ContactsForm();
        protected CreateForm CreateForm => new CreateForm();
        protected EditForm EditForm => new EditForm();
        protected DeleteForm DeleteForm => new DeleteForm();


        protected void LogStep(string stepInfo) =>
            AqualityServices.Logger.Info($"Step {StepNumber++}. {stepInfo}");

        protected IConditionalWait Wait => AqualityServices.ConditionalWait;

        protected void AddScreenshot()
        {
            File.WriteAllBytes(TestResultsScreenshot, Browser.GetScreenshot());
            TestContext.AddTestAttachment(TestResultsScreenshot);
        }
    }
}
