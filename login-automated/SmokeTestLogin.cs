using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;



namespace login_automated
{
    public class SmokeTestLogin
    {

        IWebDriver driver = new ChromeDriver(); //using OpenQA.Selenium;

        [SetUp]
        public void Setup()
        {
            DriverManager driverManager = new DriverManager();
            ChromeConfig config = new ChromeConfig();
            driverManager.SetUpDriver(config);
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void PositiveLogin()
        {
            driver.Url = "https://practicetestautomation.com/practice-test-login/";
            driver.FindElement(By.CssSelector("input[type='text']")).SendKeys("student");
            driver.FindElement(By.Name("password")).SendKeys("Password123");
            driver.FindElement(By.Id("submit")).Click();


            //Verifications
            String urlFromBrowser = driver.Url; //gets the URL from the browser
            Assert.AreEqual("https://practicetestautomation.com/logged-in-successfully/", urlFromBrowser);

            bool successMsg = driver.FindElement(By.XPath("//p[@class='has-text-align-center']/strong")).Text.Contains("Congratulations");
            Assert.AreEqual(true, successMsg);

            String hrefSignOut = driver.FindElement(By.LinkText("Log out")).GetAttribute("href");
            Assert.AreEqual("https://practicetestautomation.com/practice-test-login/", hrefSignOut);

            driver.Quit();
        }
    }
}
