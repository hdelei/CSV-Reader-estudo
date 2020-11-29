using System;
using System.Collections.Generic;
using System.Linq;

namespace TesteVitor1
{
    class Calculate
    {
        private List<People> people;
        private List<string> cities;
        private List<double> averageList;

        public Calculate(List<People> people)
        {
            this.people = people;
            BuildAverageList();            
        }

        public List<double> GetAverageList { get => averageList; }
        public List<string> GetCities { get => cities; }        

        private void BuildAverageList()
        {
            List<string> CityList = new List<string>();
            List<int> AgeList = new List<int>();

            foreach (var p in people)
            {
                CityList.Add(p.City);
                AgeList.Add(p.Age);
            }

            var distinctCities = CityList.Distinct();

            var distinctCitiesDict = new Dictionary<string, List<int>>();

            foreach (var city in distinctCities)
            {
                //keep city name
                var ages = new List<int>();
                for (int i = 0; i < CityList.Count(); i++)
                {   

                    if (city == CityList[i])
                    {
                        //keep ages
                        ages.Add(AgeList[i]);
                    }
                }
                distinctCitiesDict.Add(city, ages);
            }

            cities = new List<string>();
            var agesCount = new List<int>();            
            var listOfAgesPerCity = new List<List<int>>();

            foreach (var city in distinctCitiesDict)
            {
                agesCount.Add(city.Value.Count());
                cities.Add(city.Key);
                var agesPerCity = new List<int>();

                foreach (var age in city.Value)
                {
                    agesPerCity.Add(age);                    
                }
                listOfAgesPerCity.Add(agesPerCity);
            }

            averageList = new List<double>();
            foreach (var a in listOfAgesPerCity)
            {
                averageList.Add(Math.Round(a.Average(), 1));
            }
        }
    }
}
