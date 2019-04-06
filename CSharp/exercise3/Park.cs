using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise3
{
    //Message in linkedList
    class Message
    {
        public Car car;
        public string parkingTime = "";
        public string leavingTime = "";
        public float charge = 0.0f;

        public Message(Car c,string pt)
        {
            car = c;
            parkingTime = pt;
        }
    }

    class Park
    {
        private Random r = new Random();

        public int ParkingSpaceTotal { get; set; }      //total count of parking space
        public int ParkingSpaceResidual { get; set; }   //residual count of parking space

        public LinkedList<Message> parkedCar = new LinkedList<Message>();   //all of parked car in the park
        public LinkedList<Message> leftCar = new LinkedList<Message>();     //all of left car 

        LinkedListNode<Message> node = null;

        public Park() { ParkingSpaceTotal = 0; ParkingSpaceResidual = 0; }
        public Park(int pst,int psr) {
            if (pst < psr)
            {
                psr = pst;
            }
            ParkingSpaceTotal = pst;
            ParkingSpaceResidual = psr;

            //init messagees in parkedCar's linkedList
            int type = 0;
            Car car;
            string s = "";
            string parkingTime = "";
            Message message;

            for (int i = 0; i < (ParkingSpaceTotal - ParkingSpaceResidual); i++)
            {
                type = r.Next(0, 20);
                s = "";
                parkingTime = "";
                s += (((char)r.Next(65, 91)).ToString() + r.Next(0, 10).ToString() + r.Next(0, 10).ToString() + r.Next(0, 10).ToString() + r.Next(0, 10).ToString() + r.Next(0, 10).ToString());
                if (type % 2 != 0)
                {
                    car = new Sedan(s);
                }
                else
                {
                    car = new Truck(s);
                }
                parkingTime += (r.Next(0, 32).ToString().PadLeft(2,'0') + "-" + r.Next(0, 25).ToString().PadLeft(2, '0') + "-" + r.Next(0, 61).ToString().PadLeft(2, '0'));
                message = new Message(car, parkingTime);
                if (parkedCar.Count == 0)
                {
                    node = parkedCar.AddFirst(message);
                }
                else
                {
                    node = parkedCar.AddAfter(node,message);
                }
            }
        }

        //log
        public void printParkedCar()
        {
            printLinkedList(parkedCar);
        }
        public void printLeftCar()
        {
            printLinkedList(leftCar);
        }
        private void printLinkedList(LinkedList<Message> linkedList)
        {
            Console.WriteLine("CarType"+ "     LicensePlate"+ "     ParkingTime"+ "     LeavingTime"+"     Charge");
            foreach (var item in linkedList)
            {
                Console.WriteLine((item.car is Sedan ? "Sedan" : "Truck")+"       " + item.car.LicensePlate + "           " + item.parkingTime + "        " + item.leavingTime.PadLeft(8,'*') + "        " + item.charge.ToString().PadLeft(4,'0'));
            }
        }

        //park car function
        public void PutIn(Car car)
        {
            if (ParkingSpaceResidual <= 0)
            {
                Console.WriteLine("No residual parking space");
                return;
            }
            string parkingTime = (r.Next(0, 32).ToString().PadLeft(2, '0') + "-" + r.Next(0, 25).ToString().PadLeft(2, '0') + "-" + r.Next(0, 61).ToString().PadLeft(2, '0'));
            Message message = new Message(car, parkingTime);
            parkedCar.AddBefore(parkedCar.Last, message);
            ParkingSpaceResidual--;
        }

        //leave car function
        public void PutOut(Car car)
        {
            Message message = null;
            foreach (var item in parkedCar)
            {
                if (item.car.LicensePlate == car.LicensePlate)
                {
                    message = item;
                    break;
                }
            }
            int parkingDay = Convert.ToInt32(message.parkingTime.Substring(0, 2));
            int parkingHour = Convert.ToInt32(message.parkingTime.Substring(3, 2));
            int parkingMinute = Convert.ToInt32(message.parkingTime.Substring(6, 2));
            string leavingTime = (r.Next(parkingDay, 32).ToString().PadLeft(2, '0') + "-" + r.Next(parkingHour, 25).ToString().PadLeft(2, '0') + "-" + r.Next(parkingMinute, 61).ToString().PadLeft(2, '0'));
            parkedCar.Remove(message);
            ParkingSpaceResidual++;
            message.leavingTime = leavingTime;
            int leavingDay = Convert.ToInt32(message.leavingTime.Substring(0, 2));
            int leavingHour = Convert.ToInt32(message.leavingTime.Substring(3, 2));
            int leavingMinute = Convert.ToInt32(message.leavingTime.Substring(6, 2));
            int totalMinutes = (leavingDay - parkingDay) * 24 * 60 + (leavingHour - parkingHour) * 60 + (leavingMinute - parkingMinute);
            message.charge = totalMinutes * message.car.ChargePerMinute;
            if (leftCar.Count == 0)
            {
                node = leftCar.AddFirst(message);
            }
            else
            {
                node = leftCar.AddAfter(node, message);
            }
        }
    }
}