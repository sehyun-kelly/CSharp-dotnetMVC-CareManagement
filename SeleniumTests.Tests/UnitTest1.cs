using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.DevTools.V109.CSS;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using System.Diagnostics;

namespace SeleniumTests.Tests
{
	[TestClass]
	public class UnitTest1
	{
		//[TestMethod]
		//public void TestMethod1()
		//{
		//	//string url = "https://localhost:7121//Services";
		//	//System.setProperty("webdriver.gecko.driver", "D:\\GeckoDriver\\geckodriver.exe");

		//	//FirefoxDriver firefoxDriver = new FirefoxDriver();
		//	//WebDriver driver = new EdgeDriver();

		//	//ChromeDriver driver;

		//	//ChromeOptions chromeOptions = new ChromeOptions();
		//	//if (!Debugger.IsAttached)
		//	//	chromeOptions.AddArguments("headless");
		//	//chromeOptions.AddArguments("--start-maximized");
		//	//driver = new ChromeDriver(chromeOptions);

		//	ChromeDriver driver = new ChromeDriver();
		//	//string url = "https://www.google.com//";
		//	string url = "https://localhost:7121/Services";


		//	driver.Manage().Window.Maximize();
		//	driver.Navigate().GoToUrl(url);
		//	driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

		//	//driver.FindElement(By.LinkText("Services")).Click();


		//WebDriverManager.chromedriver().driverVersion("110.0.5481").setup();
		//WebDriver web = new WebDriver(driver);

		//}

		[TestMethod]
		public void TestService()
		{
			string url = "https://localhost:7121/Services";
			ChromeDriver driver = new ChromeDriver();

			driver.Manage().Window.Maximize();
			driver.Navigate().GoToUrl(url);
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

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
