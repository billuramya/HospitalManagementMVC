using CommonLayer.Model;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using RepoLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace RepoLayer.Service
{
    public class AppointmentRepo : IAppointmentRepo
    {
        readonly SqlConnection conn;
        readonly string connString;
        readonly IConfiguration config;

        public AppointmentRepo(IConfiguration configuration)
        {
            this.config = configuration;
            connString = configuration.GetConnectionString("HospitalDBConn");
            conn = new SqlConnection(connString);
        }

        public bool AddAppointment(AppointmentModel AMmodel)
        {
            try
            {
                using (SqlCommand Insertcmd = new SqlCommand("AddAppointment", conn))
                {
                    Insertcmd.CommandType = CommandType.StoredProcedure;
                    Insertcmd.Parameters.AddWithValue("@DoctorId", AMmodel.Doctorid);
                    Insertcmd.Parameters.AddWithValue("@PatientId", AMmodel.Patientid);
                    Insertcmd.Parameters.AddWithValue("@AppointmentDate", AMmodel.date);
                    Insertcmd.Parameters.AddWithValue("@StartTime", AMmodel.Starttime);
                    Insertcmd.Parameters.AddWithValue("@EndTime", AMmodel.Endtime);
                    Insertcmd.Parameters.AddWithValue("@Concern", AMmodel.concern);

                    conn.Open();
                    Insertcmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        public List<AppointmentModel> GetAllAppointment()
        {
            List<AppointmentModel> AMlist = new List<AppointmentModel>();
            try
            {
                if (conn != null)
                {
                    conn.Open();
                    SqlCommand GetList = new SqlCommand("AllAppointmentDetails", conn);
                    SqlDataReader reader = GetList.ExecuteReader();
                    while (reader.Read())
                    {
                        AppointmentModel appointment = new AppointmentModel()
                        {
                            AMId = (int)reader["AppointmentId"],
                            Doctorid = (int)reader["DoctorFkId"],
                            Patientid = (int)reader["PatientFkId"],
                            date = (DateTime)reader["AppointmentDate"],
                            Starttime = (TimeSpan)reader["StartTime"],
                            Endtime = (TimeSpan)reader["EndTime"],
                            concern = (string)reader["Concern"]
                        };

                        AMlist.Add(appointment);
                    }
                    return AMlist;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }


        public List<DoctorWithPatient> GetDoctorWithPatients()
        {
            List<DoctorWithPatient> DWPlist = new List<DoctorWithPatient>();
            try
            {
                using (SqlCommand GetList = new SqlCommand("getDoctorwithPatientDetails", conn))
                {
                    GetList.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    SqlDataReader reader = GetList.ExecuteReader();
                    while (reader.Read())
                    {
                        DoctorWithPatient appointment = new DoctorWithPatient()
                        {
                            DoctorName = (string)reader["DoctorNames"],
                            DoctorImage = (string)reader["DoctorImages"],
                            PatientId = (int)reader["PatientID"],
                            PatientName = (string)reader["PatientName"],
                            PatientEmail = (string)reader["PatientEmail"],
                            PatientAge = (int)reader["PatientAge"],
                            Gender = (string)reader["Gender"],
                            Concern = (string)reader["Concern"]
                        };

                        DWPlist.Add(appointment);
                    }
                }
                return DWPlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
