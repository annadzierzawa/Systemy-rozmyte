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
        
        public List<double> results = new List<double>();
        public List<double> fuzzyRule1 = new List<double>();
        public List<double> fuzzyRule2 = new List<double>();
        public List<double> resultOfRules = new List<double>();
        
        public void caculateResult() 
        {
            results.Add(product(fuzzyRule1[0], fuzzyRule2[0]));
            results.Add(product(fuzzyRule1[1], fuzzyRule2[1]));
            results.Add(product(fuzzyRule1[2], fuzzyRule2[2]));
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
        public double makeDecision()
        {
            resultOfRules.Add(1);
            resultOfRules.Add(2);
            resultOfRules.Add(3);
            double decision = 0;
            double tmp = 0;
            for (int i = 0; i < resultOfRules.Count; i++) 
            {
                decision += results[i] * resultOfRules[i];
             
            }
            for(int i=0; i<results.Count; i++)
            {
                tmp += results[i];
            }
            double result = decision / tmp;
            return result;
        }
    }
}
