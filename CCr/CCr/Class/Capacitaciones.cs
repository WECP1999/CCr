using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCr.Class
{
    class Capacitaciones
    {
        private int id;
        private DateTime diaInicio;
        private DateTime diaFinal;
        private string tipoCapacitacion;

        public int Id { get => id; set => id = value; }
        public DateTime DiaInicio { get => diaInicio; set => diaInicio = value; }
        public DateTime DiaFinal { get => diaFinal; set => diaFinal = value; }
        public string TipoCapacitacion { get => tipoCapacitacion; set => tipoCapacitacion = value; }

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
        public bool delete()
        {
            return true;
        }
        public void generateCertificates (){ 
        
        }
    }
}
