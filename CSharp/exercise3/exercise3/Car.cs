using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise3
{
    public abstract class Car
    {
        public string CarType { get; set; }
        public int LicensePlate {  get;set;  }
        public DateTime EnterTime { get; set; }
        public DateTime DepartureTime { get; set; }
        public float Payment { get; set; }
        public float UnitPrice { get; set; }
    }
}
