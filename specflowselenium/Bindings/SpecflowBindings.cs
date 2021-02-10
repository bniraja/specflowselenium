namespace specflowselenium.Bindings
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Firefox;
    using TechTalk.SpecFlow;
    using specflowselenium.Utils;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [Binding]
    class SpecflowBindings
    {
        private IWebDriver driver;

        [When(@"I start the browser")]
        public void WhenIStartTheBrowser()
        {
            driver = new FirefoxDriver();
        }

        [When(@"I navigate to '(.*)'")]
        public void WhenINavigateToHttpExample_Com(string Url)
        {
            driver.Navigate().GoToUrl(Url);
        }


        [When(@"I click on the '(.*)'")]
        public void WhenIClickOnMoreInfoLink(string moreInfoLink)
        {
            driver.FindElement(By.LinkText(moreInfoLink)).Click();
        }

        [Then(@"a link with text '(.*)' must be present")]
        public void ThenALinkWithTextMustBePresent(string linkText)
        {
            Assert.IsTrue(driver.FindElement(By.LinkText(linkText)).Displayed, $"A link with text {linkText} is not present");
        }

        [Then(@"the '(.*)' box must contain '(.*)' at index '(.*)'")]
        public void ThenTheBoxMustContainLinkAtGivenIndex(string domainNameBox, string linkName, int index)
        {
            // Check for domainbox header
            var domainNameListBoxElement = WebDriverUtilities.FindElement(driver, By.XPath($"//div[@id='sidebar_left']/div[@class='navigation_box']/h2"), 5);
            Assert.AreEqual(domainNameListBoxElement.Text, domainNameBox, true, $"Domain Box List can not find the header {domainNameBox}");

            // check for the link
            var domainNameList2ndElement = WebDriverUtilities.FindElement(driver, By.XPath($"//div[@id='sidebar_left']/div[@class='navigation_box']/ul/li[{index}]"), 5);
            Assert.AreEqual(domainNameList2ndElement.Text, linkName, true, $"Domain Box List can not find the link {linkName}");
        }

        [AfterScenario]
        public void AfterScenario()
        {
            // Dispose the browser after each scenario
            driver.Dispose();
        }
    }
}
