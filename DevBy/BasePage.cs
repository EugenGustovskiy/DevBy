using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Collections.ObjectModel;

namespace DevBy
{
    public abstract class BasePage
    {
        protected IWebDriver _driver;
        Actions _action;
        WebDriverWait _wait;

        const string POPUP_CLOSE_BUTTON_XPATH = "//button[contains(@class, 'wishes-popup')]";

        protected BasePage(IWebDriver driver)
        {
            _driver = driver;
            _action = new Actions(_driver);
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        protected void GoToUrl(string url)
        {
            _driver.Url = url;
            _driver.Manage().Window.Maximize();
        }

        protected void ClickElement(IWebElement webElement)
        {
            _action.MoveToElement(webElement);
            _action.Perform();
            webElement.Click();
        }

        protected ReadOnlyCollection<IWebElement> FindDevByElements(string xPath)
        {
            return _wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath(xPath)));
        }

        public void ClosePopupWindow()
        {
            var popupCloseButton = _wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(POPUP_CLOSE_BUTTON_XPATH)));
            ClickElement(popupCloseButton);
        }

        public void CloseProgram()
        {
            _driver.Close();
        }
    }
}
