using DevBy;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace DevByTests
{
    [TestClass]
    public class VacanciesPageTests
    {
        IWebDriver _driver;

        [TestInitialize]
        public void BeforeTest()
        {
            _driver = new ChromeDriver();
        }

        [TestMethod]
        public void ComparisonNumberVacancies()
        {
            IndexPage devByPage = new IndexPage(_driver);
            VacanciesPage vacanciesPage = devByPage.OpenInformationAbout("��������");
            vacanciesPage.ClosePopupWindow();
            vacanciesPage.SortVacanciesDescending();
        }
    }
}