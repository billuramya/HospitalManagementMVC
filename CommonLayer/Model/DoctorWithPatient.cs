using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLayer.Model
{
    public class DoctorWithPatient
    {
        public string DoctorName { get; set; }
        public string DoctorImage { get; set; }
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public string PatientEmail { get; set; }
        public string PhoneNumber { get; set; }
        public int PatientAge { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string PatientImage { get; set; }
        public string BloodGroup { get; set; }
        public string Concern { get; set; }
    }
}
