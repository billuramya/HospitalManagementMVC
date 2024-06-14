using CommonLayer.Model;
using ManagerLayer.Interface;
using RepoLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerLayer.Service
{
    public class AppointmentManager : IAppointmentManager
    {
        private readonly IAppointmentRepo appointmentRepo;
        public AppointmentManager(IAppointmentRepo appointmentRepo)
        {
            this.appointmentRepo = appointmentRepo;   
        }
        public bool AddAppointment(AppointmentModel AMmodel)
        {
            return appointmentRepo.AddAppointment(AMmodel);
        }
        public List<AppointmentModel> GetAllAppointment() {
            return appointmentRepo.GetAllAppointment(); 
        }
        public List<DoctorWithPatient> GetDoctorWithPatients()
        {
            return appointmentRepo.GetDoctorWithPatients();
        }
    }
}

