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
            Park park = new Park(10,5);
            Console.WriteLine("Cars in the park:");
            park.printParkedCar();
            Console.WriteLine();
            List<Message> mList = new List<Message>();

            Random r = new Random();
            Car c;

            for (int i = 0; i < 5; i++)
            {
                string s = (((char)r.Next(65, 91)).ToString() + r.Next(0, 10).ToString() + r.Next(0, 10).ToString() + r.Next(0, 10).ToString() + r.Next(0, 10).ToString() + r.Next(0, 10).ToString());
                int type = r.Next(0, 20);
                if (type % 2 == 0)
                {
                    c = new Sedan(s);
                }
                else
                {
                    c = new Truck(s);
                }
                park.PutIn(c);
            }

            Console.WriteLine("Cars in the park:");
            park.printParkedCar();
            Console.WriteLine();

            foreach (var item in park.parkedCar)
            {
                if (r.Next(0, 20) % 2 == 0)
                {
                    mList.Add(item);
                }
            }

            foreach (var item in mList)
            {
                park.PutOut(item.car);
            }

            Console.WriteLine("Left cars:");
            park.printLeftCar();
            Console.WriteLine();

            Console.WriteLine("Cars in the park:");
            park.printParkedCar();
            Console.WriteLine();

            while (true)
            {

            }
        }
    }
}
