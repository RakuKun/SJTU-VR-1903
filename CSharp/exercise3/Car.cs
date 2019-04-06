using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise3
{
    abstract class Car
    {
        protected Car()
        {
            licensePlate = "";
            chargePerMinute = 0.0f;
        }

        protected Car(string lp,float cpm)
        {
            licensePlate = lp;
            chargePerMinute = cpm;
        }

        protected string licensePlate;
        protected float chargePerMinute;

        public abstract string LicensePlate { get;}
        public abstract float ChargePerMinute { get;}
    }
}
