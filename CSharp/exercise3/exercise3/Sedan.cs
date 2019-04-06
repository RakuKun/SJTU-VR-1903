using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise3
{
    class Sedan : Car
    {
        public Sedan(DateTime Entertime,int Licenseplate)
        {
            CarType = "Sedan";
            UnitPrice = 8.0f;
            EnterTime = Entertime;
            LicensePlate = Licenseplate;
        }
    }
}
