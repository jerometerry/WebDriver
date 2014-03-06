namespace AcceptanceTests
{
    using System.Drawing;
    using NUnit.Framework;

    [TestFixture]
    public class GoogleSearchTests : GhostTest
    {
        private const string GoogleUrl = "http://www.google.com";
        private const string GoogleQueryBoxName = "q";
        private const string ScreenShotFileName = "google.png";

        public GoogleSearchTests()
            : base(new Size(1024, 768))
        {
        }

        [TestCase("Selenium WebDriver PhantomJS NUnit")]
        public void TestGoogleSearch(string search)
        {
            this.Open(GoogleUrl);
            var element = this.FindElementByName(GoogleQueryBoxName);
            element.SendKeys(search);
            element.Submit();
            Assert.That(this.PageTitle, Is.StringContaining(search));
            this.CaptureScreenShot(ScreenShotFileName);
        }
    }
}
