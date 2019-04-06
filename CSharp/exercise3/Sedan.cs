using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise3
{
    class Sedan : Car
    {
        public Sedan(){ }
        public Sedan(string lp, float cpm = 8.0f) : base(lp, cpm) { }

        public override string LicensePlate { get { return licensePlate; } }
        public override float ChargePerMinute { get { return chargePerMinute; } }
    }
}
