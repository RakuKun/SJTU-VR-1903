using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise3
{
    class Truck:Car
    {
        public Truck(DateTime Entertime,int Licenseplate)
        {
            CarType = "Truck";
            UnitPrice = 12.0f;
            EnterTime = Entertime;
            LicensePlate = Licenseplate;
        }

    }
}
