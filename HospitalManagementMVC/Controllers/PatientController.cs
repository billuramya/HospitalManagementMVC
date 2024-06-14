using CommonLayer.Model;
using ManagerLayer.Interface;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementMVC.Controllers
{
    public class PatientController : Controller
    {
        private readonly IPatientManager patientManager;
        public PatientController(IPatientManager patientManager)
        {
            this.patientManager = patientManager;
        }

        public IActionResult Index()
        {

            List<PatientModel> lstEmployee = new List<PatientModel>();
            lstEmployee = patientManager.GetAllPatient().ToList();

            return View(lstEmployee);
        }
        [HttpGet]
        public IActionResult AddPatient()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddPatient(PatientModel patient)
        {
            bool result = patientManager.AddPatient(patient);
            if (result) return RedirectToAction("GetAllPatientDetails");
            else return View("Index");
        }
        [HttpGet]
        public IActionResult GetAllPatientDetails()
        {
            List<PatientModel> allPatient = new List<PatientModel>();
            allPatient = patientManager.GetAllPatient().ToList();
            if (allPatient != null) return View(allPatient);
            else return View("Index");
        }
        [HttpGet]
       
        public IActionResult GetPatientById(int PatientId)
        {
            PatientModel patient = patientManager.GetPatientById(PatientId);
            if (patient != null) return View(patient);
            else return View("GetAllPatientDetails");
        }

        [HttpGet]
        public IActionResult UpdatePatient(int id)
        {
            PatientModel patient = patientManager.GetPatientById(id);

            if (patient == null)
            {
                return NotFound();
            }
            return View(patient);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdatePatient(int id, [Bind] PatientModel patient)
        {
            if (id != patient.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                bool res = patientManager.UpdatePatient(patient);
                if (res) return RedirectToAction("GetAllPatientDetails");
                return View("Index");
            }
            return View(patient);
        }
        [HttpGet]
        public IActionResult DeletePatientById(int id)
        {
            PatientModel patient = patientManager.GetPatientById(id);

            if (patient == null)
            {
                return NotFound();
            }
            return View(patient);
        }

        [HttpPost, ActionName("DeletePatientById")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            bool result = patientManager.DeletePatientById(id);
            if (result) return RedirectToAction("GetAllPatientDetails");
            return View("Index");
        }

        
    }
}