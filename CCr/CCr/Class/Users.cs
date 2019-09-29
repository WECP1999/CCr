using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCr.Class
{
    class Users
    {
        private string username;
        private string password;
        private bool state;
        private string description;

        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public bool State { get => state; set => state = value; }
        public string Description { get => description; set => description = value; }

        public bool login()
        {
            return true;
        }

        public bool signout()
        {
            return true;
        }
        public bool signup()
        {
            return true;
        }
        public bool shutdown()
        {
            return true;
        }
        public bool update()
        {
            return true;
        }
        public bool read()
        {
            return true;
        }
    }
}
