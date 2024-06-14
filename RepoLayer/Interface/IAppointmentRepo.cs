using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoLayer.Interface
{
    public interface IAppointmentRepo
    {
       public bool AddAppointment(AppointmentModel AMmodel);
       public List<AppointmentModel> GetAllAppointment();
       public List<DoctorWithPatient> GetDoctorWithPatients();
    }
}
