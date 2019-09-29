using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCr.Class
{
    class Contacts
    {
        private string description;
        private string phoneNumbre;
        private string extension;

        public string Description { get => description; set => description = value; }
        public string PhoneNumbre { get => phoneNumbre; set => phoneNumbre = value; }
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
