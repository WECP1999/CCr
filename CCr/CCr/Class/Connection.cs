using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCr.Class
{
    class Connection
    {
        private string stringConnection;

        public string StringConnection { get => stringConnection; set => stringConnection = value; }

        public bool startConnection() {
            return true;
        }
        public bool closeConnection()
        {
            return true;
        }
        public bool wrongConnection()
        {
            return true;
        }
    }
}
