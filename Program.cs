using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Systemy_rozmyte
{
    class Program
    {
        static void Main(string[] args)
        {
            List<City> cities = new List<City>();
            cities.Add(new City("Warszawa", 0.3, 0.6));
            cities.Add(new City("Kraków", 0.1, 1.0));
            cities.Add(new City("Gdańsk", 0.9, 0.9));
            cities.Add(new City("Wrocław", 0.7, 0.8));
            cities.Add(new City("Katowice", 0.1, 0.3));
            cities.Add(new City("Poznań", 0.6, 0.7));
            cities.Add(new City("Gliwice", 0.1, 0.3));

            foreach (var city in cities)
            {
                city.fuzzyRule1.Add(trapezoidal(0, 0, 0.1, 0.4, city.airPollution));
                city.fuzzyRule1.Add(triangle(0.1, 0.4, 0.5, city.airPollution));
                city.fuzzyRule1.Add(trapezoidal(0.4, 0.5, 1, 1, city.airPollution));
                city.fuzzyRule2.Add(trapezoidal(0, 0, 0.1, 0.7, city.insolation));
                city.fuzzyRule2.Add(triangle(0.1, 0.7, 0.9, city.insolation));
                city.fuzzyRule2.Add(trapezoidal(0.7, 0.9, 1, 1, city.insolation));
                city.caculateResult();
               Console.WriteLine(city.makeDecision());

            }
            Console.ReadKey();
        }
        static double triangle(double a, double b, double c, double x)
        {
            if ((a < x) && (x <= b))
            {
                return (x - a) / (b - a);
            }
            if ((b < x) && (x < c))
            {
                return (c - x) / (c - b);
            }
            return 0;
        }
        static double trapezoidal(double a, double b, double c, double d, double x)
        {
            if (x <= a) { return 0; }
            if (x > a && x <= b) { return (x - a) / (b - a); }
            if (x > b && x < c) { return 1; }
            
            if (x >= c && x <= d) { 
                if (c == d) { 
                    return 1;
                } 
                return (d - x) / (d - c); 
            }
            return 0;
        }
        
    }
}
