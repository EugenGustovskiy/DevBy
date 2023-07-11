using OpenQA.Selenium;
using System.Collections.ObjectModel;


namespace DevBy
{
    public class IndexPage : BasePage
    {
        ReadOnlyCollection<IWebElement> _menuPoints;

        const string SITE_PARTS_MENU_XPATH = "//a[contains(@class, 'navbar__nav-item')]";

        public IndexPage(IWebDriver driver) : base(driver)
        {
            GoToUrl("https://devby.io/");
            InitializeMenu();
        }

        private void InitializeMenu()
        {
            _menuPoints = FindDevByElements(SITE_PARTS_MENU_XPATH);
        }

        public VacanciesPage OpenInformationAbout(string menuText)
        {
            ClickElement(_menuPoints.Where(x => x.Text == menuText).FirstOrDefault());
            return new VacanciesPage(_driver);

        }
    }
}
