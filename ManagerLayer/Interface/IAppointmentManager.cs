using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerLayer.Interface
{
    public interface IAppointmentManager
    {
        public bool AddAppointment(AppointmentModel AMmodel);
        public List<AppointmentModel> GetAllAppointment();
        public List<DoctorWithPatient> GetDoctorWithPatients();
    }
}
