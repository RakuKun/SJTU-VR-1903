using System;
using System.Collections.Generic;

namespace exercise3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            DateTime time = DateTime.Now;
            Parking parking = new Parking();
            List<Car> carList = new List<Car>();
            
            Random random = new Random();

            //in parking
            for (int i = 0; i < 20; i++)
            {
                int type = random.Next(1, 20);
                time = time.AddMinutes(random.Next(1, 10)).AddHours(random.Next(0, 2));
                
                //sedan
                if (type % 2 == 1)
                {
                    Sedan sedan = new Sedan();
                    sedan.license = random.Next(100, 999).ToString();
                    carList.Add(sedan);
                    parking.inParking(sedan, time);
                }
                //truck
                else
                {
                    Truck truck = new Truck();
                    truck.license = random.Next(100, 999).ToString();
                    carList.Add(truck);
                    parking.inParking(truck, time);
                }
            }

            //out parking
            foreach (var car in carList)
            {
                time = time.AddMinutes(random.Next(1, 10)).AddHours(random.Next(0, 2));
                
                parking.outParking(car, time);
            }
            
            //print
            parking.printCarList();
        }
    }
}