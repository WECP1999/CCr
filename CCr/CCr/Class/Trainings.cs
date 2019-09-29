using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCr.Class
{
    class Trainings
    {
        private int id;
        private DateTime startDay;
        private DateTime endDay;
        private string typeTraining;

        public int Id { get => id; set => id = value; }
        public DateTime StartDay { get => startDay; set => startDay = value; }
        public DateTime EndDay { get => endDay; set => endDay = value; }

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
