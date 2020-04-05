using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Systemy_rozmyte
{
    public class City
    {
        public string name { get; set; }
        public double airPollution { get; set; }
        public double insolation { get; set; }

        public double decision { get; set; }

        public List<double> results = new List<double>();
        public List<double> fuzzyRule1 = new List<double>();
        public List<double> fuzzyRule2 = new List<double>();
        private List<double> resultOfRules = new List<double>();

        public void caculateResult()
        {//np.: kazdy z kazdym
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    results.Add(product(fuzzyRule1[i], fuzzyRule2[j]));


        }
        public City(string name, double airPollution, double insolation)
        {
            this.name = name;
            this.airPollution = airPollution;
            this.insolation = insolation;
        }
        double product(double a, double b)
        {
            return a * b;
        }
        public void makeDecision()
        {
            //przesłanka odpowiedniej reguły - 9 kombinacji, a więc 9 różnych wynikow
            resultOfRules.Add(1);
            resultOfRules.Add(0.8);
            resultOfRules.Add(0.5);
            resultOfRules.Add(1);
            resultOfRules.Add(0.7);
            resultOfRules.Add(0.2);
            resultOfRules.Add(0.7);
            resultOfRules.Add(0.3);
            resultOfRules.Add(0.1);
            double decision = 0;
            double tmp = 0;
            for (int i = 0; i < resultOfRules.Count; i++)
            {
                decision += results[i] * resultOfRules[i];

            }
            for (int i = 0; i < results.Count; i++)
            {
                tmp += results[i];

            }

            this.decision = decision / tmp;
        }
    }
}
