using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise3
{
    class Program
    {
        static void Main(string[] args)
        {
            Car[] cars= new Car[20];
            Random carRandom = new Random();
            for (int i = 0; i < cars.Length; i++)
            {
                int type = carRandom.Next(1, 21);
                int License = carRandom.Next(9999);
                if (License < 1000)
                {
                    License += 1000;
                }
                DateTime time = DateTime.Now.AddHours(carRandom.Next(-10,0));
                time = time.AddMinutes(carRandom.Next(-60, 0));
                if (type%2 == 0)
                {
                    Sedan sedan = new Sedan(time, License);
                    cars[i] = sedan;
                }

                else
                {
                    Truck truck = new Truck(time, License);
                    cars[i] = truck;
                }
            }
            Park park = new Park(cars);
            park.PrintCar();
            for(int i = 0; i < 8; i++)
            {
                int num = carRandom.Next(0, cars.Length);
                park.CarLeave(cars[num]);
            }

            park.PrintCar();
        }
    }
}
