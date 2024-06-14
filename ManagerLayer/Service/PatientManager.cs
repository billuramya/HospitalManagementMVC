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
    public class PatientManager : IPatientManager
    {
        private readonly IPatientRepo patientRepo;
        public PatientManager(IPatientRepo patientRepo)
        {
            this.patientRepo = patientRepo; 
        }
        public bool AddPatient(PatientModel patient)
        {
            return patientRepo.AddPatient(patient);
        }
        public List<PatientModel> GetAllPatient() { 
            return patientRepo.GetAllPatient();
        }
        public PatientModel GetPatientById(int Id)
        {
            return patientRepo.GetPatientById(Id);
        }
        public bool UpdatePatient(PatientModel patient)
        {
            return patientRepo.UpdatePatient(patient);
        }
        public bool DeletePatientById(int id)
        {
            return patientRepo.DeletePatientById(id);
        }
    }
}
