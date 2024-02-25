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

namespace smoketest_automated
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

        }


        [Test]
        public void Test1()
        {
            driver.Url = "https://www.google.com/";

        }

    }
}