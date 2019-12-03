using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace CompleteTest
{
    [TestClass]
    class UITest
    {

        #region InstanceFields

        private static IWebDriver _driver;
        private static readonly string _driverDirectory = @"C:\EASJ\UiTestDrivers";


        #endregion

        [ClassInitialize]
        public static void Setup()
        {
            _driver = new ChromeDriver(_driverDirectory);
        }

        [ClassCleanup]
        public static void TearDown()
        {
            _driver.Dispose();
        }

        [TestMethod]
        public void TestCurrentWeather()
        {
            _driver.Navigate().GoToUrl("http://localhost:3000/");
            string title = _driver.Title;
            Assert.AreEqual("Weather Station", title);

            IWebElement temperatureElement = _driver.FindElement(By.Id("currentTemp"));
            IWebElement humidityeElement = _driver.FindElement(By.Id("currentHumidity"));
            IWebElement pressureElement = _driver.FindElement(By.Id("currentPressure"));

            double temperature = double.Parse(temperatureElement.Text);
            double humidity = double.Parse(humidityeElement.Text);
            double pressure = double.Parse(pressureElement.Text);

            Thread.Sleep(10000);




        }

    }
}
