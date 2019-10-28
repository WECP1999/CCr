using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCr.Class
{
    class Participantes
    {
        private string nombre;
        private string apellido;
        private string dui;
        private string email;
        private string tel;
        private string extension;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Dui { get => dui; set => dui = value; }
        public string Email { get => email; set => email = value; }
        public string Tel { get => tel; set => tel = value; }
        public string Extension { get => extension; set => extension = value; }

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
        public bool borrar()
        {
            return true;
        }
    }
}
