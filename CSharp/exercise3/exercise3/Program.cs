using System;
using System.Collections.Generic;

namespace exercise3
{
	enum CarType
	{
		Small, Big
	}

	class Park
	{
		private LinkedList<Car> parkingCars = new LinkedList<Car>();
		private LinkedList<Car> leavingCars = new LinkedList<Car>();
		public int maxNum = 6;
		private int currentNum;

		public void ParkCar(Car car, int time)
		{
			if (currentNum < maxNum)
			{
				currentNum++;
				car.startTime = time;
				parkingCars.AddLast(car);
			}
			else
			{
				Console.WriteLine("The park is full!");
			}
		}

		public void UnparkCar(Car car, int time)
		{
			currentNum--;
			car.endTime = time;
			parkingCars.Remove(car);
			leavingCars.AddLast(car);
			Console.WriteLine("Car: " + car.id + "\tPrice: " + ((car.endTime - car.startTime) / 3600.0 * car.price));
		}

		public void PrintCars()
		{
			Console.WriteLine("Parking cars: ");
			foreach (var car in parkingCars)
			{
				Console.WriteLine(car.id + "\tpark: " + car.startTime);
			}
			Console.WriteLine("Leaving cars: ");
			foreach (var car in leavingCars)
			{
				Console.WriteLine(car.id + "\tpark: " + car.startTime + "\tunpark: " + car.endTime);
			}
		}

	}

	class Car
	{
		public string id;			// 车牌
		public CarType carType;		// 类型
		public int price;			// 单价
		public int startTime;		// 进场时间戳
		public int endTime;			// 离场时间戳
	}

	class SmallCar : Car
	{
		public SmallCar(string cid)
		{
			id = cid;
			carType = CarType.Small;
			price = 8;
		}
	}

	class BigCar : Car
	{
		public BigCar(string cid)
		{
			id = cid;
			carType = CarType.Big;
			price = 12;
		}
	}

	class Program
    {
        static void Main(string[] args)
        {
			Park park = new Park();
			SmallCar s1 = new SmallCar("small1");
			SmallCar s2 = new SmallCar("small2");
			SmallCar s3 = new SmallCar("small3");
			BigCar b1 = new BigCar("big1");
			BigCar b2 = new BigCar("big2");
			BigCar b3 = new BigCar("big3");
			BigCar b4 = new BigCar("big4");
			park.ParkCar(s1, 100);
			park.ParkCar(s2, 200);
			park.ParkCar(s3, 300);
			park.ParkCar(b1, 400);
			park.ParkCar(b2, 500);
			park.ParkCar(b3, 600);
			park.ParkCar(b4, 700);
			park.UnparkCar(s1, 3700);
			park.UnparkCar(s2, 7400);
			park.UnparkCar(b3, 2400);
			park.PrintCars();
        }
    }
}
