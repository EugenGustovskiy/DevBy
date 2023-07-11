using DevBy;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DevBy
{
    public class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();

            IndexPage devByPage = new IndexPage(driver);
            VacanciesPage vacanciesPage = devByPage.OpenInformationAbout("Вакансии");
            vacanciesPage.ClosePopupWindow();
            vacanciesPage.SortVacanciesDescending();
            vacanciesPage.GetTotalVacancies();
        }
    }
}