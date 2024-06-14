using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLayer.Model
{
    public class AppointmentModel
    {
        public int AMId { get; set; }
        public int Doctorid { get; set; }
        public int Patientid { get; set; }
        public DateTime date { get; set; }
        public TimeSpan Starttime { get; set; }
        public TimeSpan Endtime { get; set; }
        public string concern { get; set; }

    }
}
