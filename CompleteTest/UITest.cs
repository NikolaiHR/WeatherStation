using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using UDPProxy;

namespace CompleteTest
{
    [TestClass]
    public class UITest
    {

        #region InstanceFields

        private static IWebDriver _driver;
        private static readonly string _driverDirectory = @"C:\EASJ\UiTestDrivers";
        private static UDPProxy.Proxy _proxy;

        #endregion

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            _driver = new ChromeDriver(_driverDirectory);
            _proxy = new UDPProxy.Proxy();
            
            
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
            _proxy.Start();

            IWebElement temperatureElement = _driver.FindElement(By.Id("currentTemp"));
            IWebElement humidityeElement = _driver.FindElement(By.Id("currentHumidity"));
            IWebElement pressureElement = _driver.FindElement(By.Id("currentPressure"));

            Task task = Task.Delay(TimeSpan.FromSeconds(11));
            task.Wait();

            double temperature = double.Parse(temperatureElement.Text);
            double humidity = double.Parse(humidityeElement.Text);
            double pressure = double.Parse(pressureElement.Text);

            Task task2 = Task.Delay(TimeSpan.FromSeconds(8));
            task2.Wait();

            double temperature2 = double.Parse(temperatureElement.Text);
            double humidity2 = double.Parse(humidityeElement.Text);
            double pressure2 = double.Parse(pressureElement.Text);

            Assert.IsTrue(Math.Abs(temperature-temperature2) < 2);
            Assert.IsTrue(Math.Abs(humidity-humidity2) < 2);
            Assert.IsTrue(Math.Abs(pressure-pressure2) < 2);
        }

        [TestMethod]
        public void TestGetCurrentOutsideWeatherCondition()
        {
            _driver.Navigate().GoToUrl("http://localhost:3000/");
            string title = _driver.Title;
            Assert.AreEqual("Weather Station", title);

            IWebElement buttonElement = _driver.FindElement(By.Id("currentOutsideWeatherConditionButton"));
            buttonElement.Click();

            Task task = Task.Delay(TimeSpan.FromSeconds(3));
            task.Wait();

            IWebElement weatherConditionElement = _driver.FindElement(By.Id("currentOutsideWeatherCondition"));
            string weatherCondition = weatherConditionElement.Text;

            Assert.IsTrue(!String.IsNullOrWhiteSpace(weatherCondition));
            Assert.IsTrue(weatherCondition.ToUpper().Contains("SOL")
                          || weatherCondition.ToUpper().Contains("SKY") || weatherCondition.ToUpper().Contains("REGN")
                          || weatherCondition.ToUpper().Contains("HIMMEL") || weatherCondition.ToUpper().Contains("BLÆS"));
        }

    }
}
