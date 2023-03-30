using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.DevTools.V109.CSS;

namespace SeleniumTests.Tests
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestMethod1()
		{
			string url = "https://localhost:7121";
			ChromeDriver driver = new ChromeDriver();
			driver.Manage().Window.Maximize();
			driver.Navigate().GoToUrl(url);
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

			driver.FindElement(By.LinkText("Client")).Click();
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
			driver.FindElement(By.LinkText("Create New")).Click();
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
			driver.FindElement(By.Id("Name")).SendKeys("Marge Simpson");
			driver.FindElement(By.Id("Address")).SendKeys("Springfield");
			driver.FindElement(By.XPath("//Input[@type='submit']")).Click();
		}
	}
}
