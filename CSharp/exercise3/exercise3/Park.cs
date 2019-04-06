using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise3
{
    class Park
    {
        private Node EnterHead = null;
        private Node LeftHead = null;
        public int carnum=0;

        public class Node
        {
            public Car car;
            public Node next;
            public Node(Car c)
            {
                car = c;
            }
        }

        public Park(params Car[] cars)
        {
            EnterHead = new Node(new Truck(DateTime.MinValue, -1));
            LeftHead = new Node(new Truck(DateTime.MinValue, -1));
            if (cars != null)
            {
                Node prev = EnterHead;
                carnum = cars.Length;
                for (int i = 0; i < cars.Length; i++)
                {
                    Node node = new Node(cars[i]);
                    prev.next = node;
                    prev = node;
                }
            }
        }


        public void CarEnter(Car car)
        {
            if (EnterHead != null)
            {
                Node LastCar = EnterHead;
                while (LastCar.next != null)
                {
                    LastCar = LastCar.next;
                }

                Node NewCar = new Node(car);
                LastCar.next = NewCar;
                carnum++;
            }
       
  
        }


        public void CarLeave(Car car)
        {
            if (EnterHead!= null)
            {
                Node prev = EnterHead;
                Node current = prev;

                while (current != null)
                {
                    if (current.car.LicensePlate == car.LicensePlate)
                    {
                        prev.next = current.next;
                        current.next = null;
                        current.car.DepartureTime = DateTime.Now;
                        SetLeftCar(current.car);
                        SetCarPayment(current.car);
                        break;
                    }
                    else
                    {
                        prev = current;
                        current = current.next;
                    }

                }
            }




        }

        private void SetCarPayment(Car car)
        {
            float unit = car.UnitPrice;
            TimeSpan time = car.DepartureTime - car.EnterTime;
            float hours = (float)time.TotalHours;
            car.Payment = hours * unit;
        }

        private void SetLeftCar(Car car)
        {
            if (LeftHead != null)
            {
                Node LastCar = LeftHead;
                while (LastCar.next != null)
                {
                    LastCar = LastCar.next;
                }

                Node NewCar = new Node(car);
                LastCar.next = NewCar;
                carnum--;
            }

        }

        public void PrintCar()
        {
            if (EnterHead != null && EnterHead.next != null)
            {
                Console.WriteLine("Park:"+carnum);
                Node n = EnterHead.next;
                while (n != null)
                {
                    Console.WriteLine(n.car.CarType);
                    Console.WriteLine(n.car.LicensePlate);
                    Console.WriteLine(n.car.EnterTime);
                    Console.WriteLine("----------------");
                    n = n.next;
                }
            }
            else
            {
                Console.WriteLine("No Car In Park");
            }

            Console.WriteLine();

            if (LeftHead != null && LeftHead.next != null)
            {
                Console.WriteLine("Left:");
                Node n = LeftHead.next;
                while (n != null)
                {
                    Console.WriteLine(n.car.CarType);
                    Console.WriteLine(n.car.LicensePlate);
                    Console.WriteLine(n.car.EnterTime);
                    Console.WriteLine(n.car.DepartureTime);
                    Console.WriteLine(n.car.Payment);
                    Console.WriteLine("----------------");
                    n = n.next;
                }
            }
            else
            {
                Console.WriteLine("No Car Left");
            }
        }
    }


}
