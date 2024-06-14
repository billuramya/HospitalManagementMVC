using CommonLayer.Model;
using ManagerLayer.Interface;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementMVC.Controllers
{
    public class AppointmentController : Controller
    {
        readonly IAppointmentManager appointmentManager;
        public AppointmentController(IAppointmentManager appointment)
        {
            this.appointmentManager = appointment;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AddAppointment()
        {
            return View();  
        }
        [HttpPost]
        public IActionResult AddAppointment(AppointmentModel AM)
        {
            bool result = appointmentManager.AddAppointment(AM);
            int patientId = (int)@HttpContext.Session.GetInt32("patientId");
            if (result && patientId > 0) return RedirectToAction("GetAllDoctorDetails", "Doctor");
            else if (result) return RedirectToAction("AddAppointment");
            return View("Index");
        }
        [HttpGet]
        public IActionResult GetAllAppointmentDetails()
        {
            List<AppointmentModel> allAppointment = new List<AppointmentModel>();
            allAppointment = appointmentManager.GetAllAppointment().ToList();
            if (allAppointment != null) return View(allAppointment);
            return View("Index");
        }
        [HttpGet]
        public IActionResult GetDoctorWithPatients()
        {
            List<DoctorWithPatient> DocWithPatientAppointment = new List<DoctorWithPatient>();
            DocWithPatientAppointment = appointmentManager.GetDoctorWithPatients().ToList();
            if (DocWithPatientAppointment != null) return View(DocWithPatientAppointment);
            return View("Index");
        }
    }
}