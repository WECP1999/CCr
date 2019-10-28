using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCr.Class
{
    class Contactos
    {
        private string descripcion;
        private string tel;
        private string extension;

        public string Descripcion { get => descripcion; set => descripcion = value; }
        public string Tel { get => tel; set => tel = value; }
        public string Extension { get => extension; set => extension = value; }

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
    }
}
