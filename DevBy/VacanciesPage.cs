using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DevBy
{
    public class VacanciesPage : BasePage
    {
        ReadOnlyCollection<IWebElement> _specializations;

        const string SPECIALIZATIONS_PAGE_XPATH = "//span[@class='radio']";
        const string SPECIALIZATIONS_NUMBER_XPATH = "//h1[contains(@class, 'vacancies-list__header-title')]";


        public VacanciesPage(IWebDriver driver) : base (driver)
        {
        }

        private void InitializeSpecializations()
        {
            _specializations = FindDevByElements(SPECIALIZATIONS_PAGE_XPATH);
        }

        public Dictionary<string, int> GetVacanciesTitlesAndNumber()
        {
            var vacanciesTitlesAndNumber = new Dictionary<string, int>();
            InitializeSpecializations();

            foreach (var specialization in _specializations)
            {
                specialization.Click();
                Thread.Sleep(3000);
                var vacanciesNumberElement = _driver.FindElement(By.XPath(SPECIALIZATIONS_NUMBER_XPATH));
                var vacanciesNumber = int.Parse(vacanciesNumberElement.Text.Split(" ").First());
                //Console.WriteLine($"{specialization.Text}: {vacanciesNumber}");
                vacanciesTitlesAndNumber.Add(specialization.Text, vacanciesNumber);
            }
            return vacanciesTitlesAndNumber;
        }

        public Dictionary<string, int> SortVacanciesDescending()
        {
            var vacancies = GetVacanciesTitlesAndNumber();
            var sortVacancies = vacancies.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            foreach (var vacancy in sortVacancies)
            {
                Console.WriteLine($"{vacancy.Key}: {vacancy.Value}");
            }
            return sortVacancies;
        }

        public int GetTotalVacancies()
        {
            var vacancies = GetVacanciesTitlesAndNumber();
            var totalVacancies = vacancies.Values.Sum();
            return totalVacancies;
        }
    }
}