using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCr.Class
{
    class Pagos
    {
        private DateTime fecha;
        private double pago;

        public DateTime Fecha { get => fecha; set => fecha = value; }
        public double Pago { get => pago; set => pago = value; }

        public bool crear()
        {
            return true;
        }
        public bool leer()
        {
            return true;
        }
        public bool actualizar()
        {
            return true;
        }
    }
}
