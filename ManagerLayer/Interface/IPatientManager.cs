using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerLayer.Interface
{
    public interface IPatientManager
    {
        public bool AddPatient(PatientModel patient);
        public List<PatientModel> GetAllPatient();
        public PatientModel GetPatientById(int Id);
        public bool UpdatePatient(PatientModel patient);
        public bool DeletePatientById(int id);

    }
}
