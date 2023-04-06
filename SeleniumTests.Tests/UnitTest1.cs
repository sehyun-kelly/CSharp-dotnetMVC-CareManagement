using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumTests.Tests
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestService()
		{
			string urlServices = "https://localhost:7121/Services";
			string urlQualification = "https://localhost:7121/Qualifications";
			ChromeDriver driver = new ChromeDriver();

            // This redirects to the Qualifications URL
            driver.Manage().Window.Maximize();
			driver.Navigate().GoToUrl(urlQualification);
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

			// This tests creating a qualification
			driver.FindElement(By.Id("CreateQualification")).Click();
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
			driver.FindElement(By.Id("QualificationDescription")).SendKeys("QD1");
			driver.FindElement(By.XPath("//Input[@type='submit']")).Click();


            // This redirects to the Services URL
            driver.Navigate().GoToUrl(urlServices);
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

			// This tests creating a service
			driver.FindElement(By.LinkText("Create New")).Click();
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
			driver.FindElement(By.Id("Hours")).SendKeys("8");
			driver.FindElement(By.Id("Rate")).SendKeys("1");
			driver.FindElement(By.Id("Type")).SendKeys("ServiceTypeTest");
			driver.FindElement(By.XPath("//Input[@type='submit']")).Click();

			// This tests editing a service
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
			driver.FindElement(By.LinkText("Edit")).Click();
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
			driver.FindElement(By.Id("Hours")).Clear();
			driver.FindElement(By.Id("Rate")).Clear();
			driver.FindElement(By.Id("Type")).Clear();
			driver.FindElement(By.Id("Hours")).SendKeys("9");
			driver.FindElement(By.Id("Rate")).SendKeys("1");
			driver.FindElement(By.Id("Type")).SendKeys("TypeEdited");
			driver.FindElement(By.XPath("//Input[@type='submit']")).Click();

			// This tests viewing a service
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
			driver.FindElement(By.LinkText("Details")).Click();
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
			driver.FindElement(By.LinkText("Back to List")).Click();

			// This tests deleting a service
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
			driver.FindElement(By.LinkText("Delete")).Click();
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
			driver.FindElement(By.XPath("//Input[@type='submit']")).Click();
		}


        [TestMethod]
        public void TestQualification()
        {
            string urlQualification = "https://localhost:7121/Qualifications";
            ChromeDriver driver = new ChromeDriver();

            // This redirects to the Qualifications URL
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(urlQualification);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            // This tests creating a qualification
            driver.FindElement(By.Id("CreateQualification")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.Id("QualificationDescription")).SendKeys("QD2");
            driver.FindElement(By.XPath("//Input[@type='submit']")).Click();

            // This tests editing a qualification
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.LinkText("Edit")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.Id("QualificationDescription")).Clear();
            driver.FindElement(By.Id("QualificationDescription")).SendKeys("QD3");
            driver.FindElement(By.XPath("//Input[@type='submit']")).Click();

            // This tests viewing a qualification
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.LinkText("Details")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.LinkText("Back to List")).Click();

            // This tests deleting a qualification
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.LinkText("Delete")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.XPath("//Input[@type='submit']")).Click();
        }


        [TestMethod]
        public void TestInvoice()
        {
            string urlInvoice = "https://localhost:7121/Invoices";
            ChromeDriver driver = new ChromeDriver();

            // This redirects to the Invoice URL
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(urlInvoice);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            // This tests creating an invoice
            driver.FindElement(By.LinkText("Create New")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            //driver.FindElement(By.Id("DatePaid")).Click();
            //driver.FindElement(By.Id("StartDate")).Click();

            // Send date and time to the DateTime element
            IWebElement startDate = driver.FindElement(By.Id("StartDate"));
            //Fill date as yyyy/mm/dd
            driver.FindElement(By.Id("StartDate")).Click();
            startDate.SendKeys("2023\t03-01");
            //startDate.SendKeys("03 01");
            //Press tab to shift focus to time field
            //startDate.SendKeys(Keys.Tab);
            //Fill time as 02:45 PM
            startDate.SendKeys("0245PM");

            IWebElement endDate = driver.FindElement(By.Id("EndDate"));            //Fill date as yyyy/mm/dd
            driver.FindElement(By.Id("EndDate")).Click();
            endDate.SendKeys("2023\t04-01");
            endDate.SendKeys("0245PM");

            IWebElement datePaid = driver.FindElement(By.Id("DatePaid"));
            driver.FindElement(By.Id("DatePaid")).Click();
            datePaid.SendKeys("2023\t04-01");
            //datePaid.SendKeys("0600PM");

            //IWebElement endDate = driver.FindElement(By.Id("EndDate"));
            ////Fill date as yyyy/mm/dd
            //endDate.SendKeys("2023-04-01");
            ////Press tab to shift focus to time field
            //endDate.SendKeys(Keys.Tab);
            ////Fill time as 02:45 PM
            //endDate.SendKeys("0245PM");

            //IWebElement datePaid = driver.FindElement(By.Id("DatePaid"));
            ////Fill date as yyyy/mm/dd
            //datePaid.SendKeys("2023-04-01");
            ////Press tab to shift focus to time field
            //datePaid.SendKeys(Keys.Tab);
            ////Fill time as 02:45 PM
            //datePaid.SendKeys("0600PM");



            //var today = DateTime.Today;
            //driver.FindElement(By.Id("DatePaid")).Click();
            //driver.FindElement(By.LinkText(today.Day.ToString())).Click();



            driver.FindElement(By.XPath("//Input[@type='submit']")).Click();

            // This redirects to the Invoice URL
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(urlInvoice);

            // This tests editing a invoice
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.LinkText("Edit")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.XPath("//Input[@type='submit']")).Click();

            // This tests viewing a invoice
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.LinkText("Details")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.LinkText("Back to List")).Click();

            // This tests deleting a invoice
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.LinkText("Delete")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.XPath("//Input[@type='submit']")).Click();
        }
    }
}
