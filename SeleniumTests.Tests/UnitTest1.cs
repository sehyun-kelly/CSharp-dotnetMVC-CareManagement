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
			string url = "https://localhost:7121/Services";
			ChromeDriver driver = new ChromeDriver();

			// This redirects to the URL
			driver.Manage().Window.Maximize();
			driver.Navigate().GoToUrl(url);
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

			// This tests creating a service
			driver.FindElement(By.LinkText("Services")).Click();
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
			driver.FindElement(By.LinkText("Create New")).Click();
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
			driver.FindElement(By.Id("Hours")).SendKeys("8");
			driver.FindElement(By.Id("Type")).SendKeys("service type");
			driver.FindElement(By.XPath("//Input[@type='submit']")).Click();

			// This tests editing a service
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
			driver.FindElement(By.LinkText("Edit")).Click();
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
			driver.FindElement(By.Id("Hours")).Clear();
			driver.FindElement(By.Id("Type")).Clear();
			driver.FindElement(By.Id("Hours")).SendKeys("9");
			driver.FindElement(By.Id("Type")).SendKeys("type edited");
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
	}
}
