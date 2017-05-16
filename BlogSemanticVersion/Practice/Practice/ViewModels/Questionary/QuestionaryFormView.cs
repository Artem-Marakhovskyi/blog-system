using System.Collections.Generic;

namespace Practice.ViewModels.Questionary
{
    public class QuestionaryFormView
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public int Age { get; set; }
        public string Mark { get; set; }
        public string Browser { get; set; }
        public string[] Preferable { get; set; }

        public string GetPreferable
        {
            get
            {
                var prefereble = "";
                foreach (var item in Preferable)
                {
                    prefereble += " " + item;
                }
                return prefereble;
            }
        }

        public List<string> ListOfCities()
        {
            var city = new List<string>();
            city.Add("Kyiv");
            city.Add("Kharkov");
            city.Add("Donetsk");
            city.Add("Lviv");
            city.Add("Dnepr");
            city.Add("Poltava");

            return city;
        }

        public List<string> ListOfBrowsers()
        {
            var browser = new List<string>();
            browser.Add("Google Chrome");
            browser.Add("Mozilla");
            browser.Add("Microsoft Edge");
            browser.Add("Opera");

            return browser;
        }
    }
}