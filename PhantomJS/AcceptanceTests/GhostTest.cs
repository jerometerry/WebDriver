namespace AcceptanceTests
{
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.PhantomJS;

    public class GhostTest
    {
        private readonly Size windowSize;
        private IWebDriver driver;

        public GhostTest(Size windowSize)
        {
            this.windowSize = windowSize;
        }

        protected string PageTitle
        {
            get
            {
                return this.driver.Title;
            }
        }

        [SetUp]
        public void Init()
        {
            var pjs = new PhantomJSDriver();
            pjs.Manage().Window.Size = this.windowSize;
            this.driver = pjs;
        }

        [TearDown]
        public void TearDown()
        {
            this.driver.Quit();
        }

        protected void Open(string url)
        {
            this.driver.Navigate().GoToUrl(url);
        }

        protected IWebElement FindElementByName(string name)
        {
            return this.driver.FindElement(By.Name(name));
        }

        protected IWebElement FindAnchorByText(string txt)
        {
            return this.driver.FindElement(By.XPath(string.Format("//a[text()='{0}']", txt)));
        }

        protected IWebElement FindInputByName(string name)
        {
            return this.driver.FindElement(By.XPath(string.Format("//input[@name='{0}']", name)));
        }

        protected IWebElement FindElementById(string id)
        {
            return this.driver.FindElement(By.Id(id));
        }

        protected void CaptureScreenShot(string fileName)
        {
            if (!fileName.EndsWith(".png", StringComparison.InvariantCultureIgnoreCase))
            {
                fileName += ".png";
            }

            ((ITakesScreenshot)this.driver).GetScreenshot().SaveAsFile(fileName, ImageFormat.Png);
        }
    }
}
