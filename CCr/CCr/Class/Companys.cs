using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCr.Class
{
    class Companys
    {
        private string name;
        private string address;
        private int numberParticipants;
        private string email;

        public string Name { get => name; set => name = value; }
        public string Address { get => address; set => address = value; }
        public int NumberParticipants { get => numberParticipants; set => numberParticipants = value; }
        public string Email { get => email; set => email = value; }

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
