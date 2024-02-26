using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Support.UI;

namespace google_automated
{
    internal class SmokeTestGoogle
    {
        IWebDriver driver = new ChromeDriver(); // properties of the IWebDriver Class: URL
        //IWebDriver driverF = new FirefoxDriver();//Firefox
        //IWebDriver driverE = new EdgeDriver();//Edge

        [SetUp]
        public void Setup()
        {
            //Initializing Chrome Browser
            DriverManager driverManager = new DriverManager(); //object created using WebDriverManager namespace;
            ChromeConfig configChrome = new ChromeConfig(); //object created using WebDriverManager.DriverConfigs.Impl namespace;
            //FirefoxConfig configFirefox = new FirefoxConfig(); //Firefox
            //EdgeConfig configEdge = new EdgeConfig(); //Edge

            driverManager.SetUpDriver(configChrome);
            //driverManager.SetUpDriver(configFirefox); //Firefox
            //driverManager.SetUpDriver(configEdge); //Edge

            /* Optimized version of the code above for Chrome:
             * new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
             */

            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);//Implicit wait:
        }


        [Test]
        public void RegularEditedSearch()
        {
            //Perform a regular seach, go back to homepage
            driver.Url = "https://www.google.com/";
            driver.FindElement(By.XPath("//textarea[@class='gLFyf']")).SendKeys("recipes");
            driver.FindElement(By.XPath("//textarea[@class='gLFyf']")).SendKeys(Keys.Enter);
            driver.FindElement(By.XPath("//textarea[@class='gLFyf']")).Clear();
            driver.FindElement(By.XPath("//textarea[@class='gLFyf']")).SendKeys("Salads");
            driver.Navigate().Back();
            IWebElement image = driver.FindElement(By.ClassName("lnXdpd"));
            Assert.IsNotNull(image);
            driver.Quit();
        }


        [Test]
        public void SearchImages()
        {
            //Search images, go back to homepage
            driver.Url = "https://www.google.com/";
            driver.FindElement(By.XPath("//textarea[@class='gLFyf']")).SendKeys("famous places");
            driver.FindElement(By.XPath("//textarea[@class='gLFyf']")).SendKeys(Keys.Enter);
            driver.FindElement(By.ClassName("FMKtTb")).Click();

            //Explicit wait of 5 seconds:
            //WebDriverWait time = new WebDriverWait(driver, TimeSpan.FromSeconds(8)); //WebDriverWait class comes from Selenium.Support namespace
            //time.Until(ExpectedConditions.ElementExists(By.ClassName("F1hUFe"))); //ExpectedConditions class comes fromSeleniumExtras.WaitHelpers namespace
            driver.Navigate().Back();
            driver.Navigate().Back();
            driver.Quit();
        }


        
        

    }
}