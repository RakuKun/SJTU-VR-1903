using System;
using System.Collections.Generic;

namespace exercise3
{
    public class Parking
    {
        private int numOfRemainPlace;
        private int numOfAlreadyUsedPlace;
        private List<Car> carListInParking;
        private List<Car> carListOutParking;

        public Parking()
        {
            numOfRemainPlace = 100;
            numOfAlreadyUsedPlace = 0;
            carListInParking = new List<Car>();
            carListOutParking = new List<Car>();
        }

        public void inParking(Car car, DateTime inParkingTime)
        {
            if (numOfRemainPlace > 0)
            {
                car.inParkingTime = inParkingTime;
                carListInParking.Add(car);
                numOfRemainPlace--;
                numOfAlreadyUsedPlace++;
            }
            else
            {
                Console.WriteLine("Parking is full");
            }

        }

        public void outParking(Car car, DateTime outParkingTime)
        {
            if (carListInParking.Contains(car))
            {
                car.outParkingTime = outParkingTime;
                carListInParking.Remove(car);
                numOfRemainPlace++;
                numOfAlreadyUsedPlace--;

                TimeSpan inTime = new TimeSpan(car.inParkingTime.Ticks);
                TimeSpan outTime = new TimeSpan(car.outParkingTime.Ticks);
                car.fee = car.feePerHour * (int) outTime.Subtract(inTime).TotalHours;
                carListOutParking.Add(car);
            }
            else
            {
                Console.WriteLine("this car is not exist");
            }
        }

        public void printCarList()
        {
            foreach (var car in carListOutParking)
            {
                car.printInformation();
            }
        }

        public void printParkingUse()
        {
            Console.WriteLine($"numOfRemainPlace: {numOfRemainPlace}; numOfAlreadyUsedPlace: {numOfAlreadyUsedPlace};");
        }
    }
}