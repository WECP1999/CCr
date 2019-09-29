using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCr.Class
{
    class Trainers
    {
        private string name;
        private string lastname;

        public string Name { get => name; set => name = value; }
        public string Lastname { get => lastname; set => lastname = value; }

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
