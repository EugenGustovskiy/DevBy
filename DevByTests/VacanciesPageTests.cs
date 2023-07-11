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
        public void TotalVacanciesTest()
        {
            IndexPage devByPage = new IndexPage(_driver);
            VacanciesPage vacanciesPage = devByPage.OpenInformationAbout("Вакансии");
            vacanciesPage.ClosePopupWindow();
            Assert.AreEqual(106, vacanciesPage.GetTotalVacancies());
        }

        [TestCleanup]
        public void AfterTest()
        {
            _driver.Close();
        }
    }
}