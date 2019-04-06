using System;

namespace exercise3
{
    public abstract class Car
    {
        public string license { get; set; }
        public int feePerHour { get; set; }
        public DateTime inParkingTime { get; set; }
        public DateTime outParkingTime { get; set; }
        public int fee { get; set; }

        public Car()
        {
            license = new Random().Next(100, 999).ToString();
            inParkingTime = new DateTime();
            outParkingTime = new DateTime();
        }

        public void printInformation()
        {
            Console.WriteLine($"license: {license}; carType: {GetType().Name}; feePerHour: {feePerHour}; inParkingTime: {inParkingTime}; outParkingTime: {outParkingTime}; feeTotal: {fee}");
        }
    }
}