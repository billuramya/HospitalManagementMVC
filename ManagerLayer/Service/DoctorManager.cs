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
 public class DoctorManager :IDoctorManager
    {
        private readonly IDoctorRepo doctorRepo;
        public DoctorManager(IDoctorRepo doctorRepo)
        {
            this.doctorRepo = doctorRepo;
        }
       public bool AddDoctor(DoctorModel doctor)
        {
            return doctorRepo.AddDoctor(doctor);
        }
        public List<DoctorModel> GetAllDoctor()
        {
            return  doctorRepo.GetAllDoctor();
        }
        public DoctorModel GetDoctorById(int id)
        {
            return doctorRepo.GetDoctorById(id);
        }
       public bool UpdateDoctor(DoctorModel doctor)
        {
            return doctorRepo.UpdateDoctor(doctor);
        }
        public bool DeleteDoctorById(int id)
        {
            return doctorRepo.DeleteDoctorById(id);
        }
    }
}
