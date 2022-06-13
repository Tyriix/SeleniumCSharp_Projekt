// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumCSharp.BaseClass;
using System;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Edge;

namespace SeleniumCSharp
{
    [TestFixture]
    public class OrderSkipAttribute
    {
        
        [Test, Order(3), Category("OrderSkipAttribute")]
        public void TestMethod1()
        {
            Assert.Ignore("Defect 12345");
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://www.facebook.com/";
            IWebElement emailTextField = driver.FindElement(By.XPath(".//*[@id='email']"));
            emailTextField.SendKeys("Selenium C#");
            driver.Close();
        }

        [Test, Order(2), Category("OrderSkipAttribute")]
        public void TestMethod2()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Url = "https://www.facebook.com/";
            IWebElement emailTextField = driver.FindElement(By.XPath(".//*[@id='email']"));
            emailTextField.SendKeys("Selenium C#");
            driver.Close();
        }

        //Nie działa poprawnie ze względu wycofania Internet Explorer z użytku
        [Test, Order(1), Category("OrderSkipAttribute")]
        public void TestMethod3()
        {
            IWebDriver driver = new InternetExplorerDriver();
            driver.Url = "https://www.facebook.com/";
            IWebElement emailTextField = driver.FindElement(By.XPath(".//*[@id='email']"));
            emailTextField.SendKeys("Selenium C#");
            driver.Close();
        }

        //Dodałem MSEdge ze względu wycofania InternetExplorer(Powyższy test InternetExplorer nie działa poprawnie)
        [Test, Order(0), Category("OrderSkipAttribute")]
        public void TestMethod4()
        {
            IWebDriver driver = new EdgeDriver();
            driver.Url = "https://www.facebook.com/";
            IWebElement emailTextField = driver.FindElement(By.XPath(".//*[@id='email']"));
            emailTextField.SendKeys("Selenium C#");
            driver.Close();
        }
    }   
}
