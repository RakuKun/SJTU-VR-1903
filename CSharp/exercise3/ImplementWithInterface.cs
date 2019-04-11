using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    interface ICar
    {
        float ComputeFee(DateTime inTime, DateTime outTime);
        void printInfo();
    }

    class Car : ICar
    {
        float feePerMinute = 0.0f;
        float fee = 0.0f;
        public string id { get;}
        int type = -1;
        DateTime inTime { get; set; }
        DateTime outTime { get; set; }
        public Car(string id, int type)
        {
            this.id = id;
            this.type = type;
            if (this.type == 0)
            {
                feePerMinute = 8.0f;
            }
            else
            {
                feePerMinute = 12.0f;
            }
        }
        public void InPark(DateTime inTime)
        {
            this.inTime = inTime;
        }
        public void leave(DateTime outTime)
        {
            this.outTime = outTime;
            fee = ComputeFee(this.inTime, this.outTime);
        }
        public float ComputeFee(DateTime inTime,DateTime outTime)
        {
            TimeSpan span = outTime - inTime;
            return feePerMinute * (int)span.TotalMinutes;
        }
        public void printInfo()
        {
            if (outTime == null)
            {
                Console.WriteLine($"{type} \t {id} \t {inTime}");
            }
            else
            {
                Console.WriteLine($"{type} \t {id} \t {inTime} \t {outTime} \t {fee}");
            }
           
        }
    }

    class Park
    {
        LinkedList<ICar> parkedCar = new LinkedList<ICar>();
        LinkedList<ICar> leftCar = new LinkedList<ICar>();

        public int parkedCarCount { get { return parkedCar.Count; } }

        public void InPark(string id,int type,DateTime inTime)
        {

            Car c = new Car(id, type);
            c.InPark(inTime);
            if(!parkedCar.Contains(c))
                parkedCar.AddLast(c);
        }

        public void leavePark(string id,DateTime outTime)
        {
            Car c = null;
            foreach (var item in parkedCar)
            {
                if (id == ((Car)item).id)
                {
                    c = (Car)item;
                }
            }
            if (c != null)
            {
                c.leave(outTime);
                parkedCar.Remove(c);
                leftCar.AddLast(c);
            }
        }

        public void printParkedCar()
        {
            foreach (var item in parkedCar)
            {
                item.printInfo();
            }
            Console.WriteLine();
        }

        public void printLeftCar()
        {
            foreach (var item in leftCar)
            {
                item.printInfo();
            }
            Console.WriteLine();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            Park p = new Park();
            List<string> ids = new List<string>();
            for (int i = 0; i < 5; i++)

            {
                string s = (((char)r.Next(65, 91)).ToString() + r.Next(0, 10).ToString() + r.Next(0, 10).ToString() + r.Next(0, 10).ToString() + r.Next(0, 10).ToString() + r.Next(0, 10).ToString());
                int type = r.Next(0, 20);
                if (type % 2 == 0)
                {
                    p.InPark(s, 0, DateTime.Now.AddMinutes(r.Next(0,10000)));
                }
                else
                {
                    p.InPark(s, 1, DateTime.Now.AddMinutes(r.Next(0, 10000)));
                }

                if (r.Next(0, 20) % 2 == 0)
                {
                    ids.Add(s);
                }
            }

            p.printParkedCar();

            int count = ids.Count;
            for (int i = 0; i < count; i++)
            {
                p.leavePark(ids[i], DateTime.Now.AddMinutes(r.Next(10000, 100000)));
            }

            p.printLeftCar();

            while (true)
            {

            }
        }
    }

}
