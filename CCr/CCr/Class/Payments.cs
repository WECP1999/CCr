using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCr.Class
{
    class Payments
    {
        private DateTime payDay;
        private double pay;

        public DateTime PayDay { get => payDay; set => payDay = value; }
        public double Pay { get => pay; set => pay = value; }

        public bool create()
        {
            return true;
        }
        public bool read()
        {
            return true;
        }
        public bool update()
        {
            return true;
        }
    }
}
