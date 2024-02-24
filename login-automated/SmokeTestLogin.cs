using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace login_automated
{
    internal class SmokeTestLogin
    {
         
        [SetUp]
        public void Setup()
        {
            DriverManager driverManager = new DriverManager(); 
            ChromeConfig config = new ChromeConfig(); 

            driverManager.SetUpDriver(config);
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    
    }
}
