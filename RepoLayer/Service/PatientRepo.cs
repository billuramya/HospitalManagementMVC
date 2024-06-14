using CommonLayer.Model;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using RepoLayer.Interface;
using System.Data;

public class PatientRepo : IPatientRepo
{
    readonly string connString;
    readonly IConfiguration config;

    public PatientRepo(IConfiguration configuration)
    {
        this.config = configuration;
        connString = configuration.GetConnectionString("HospitalDBConn");
    }

    public bool AddPatient(PatientModel patient)
    {
        try
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("AddPatient", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Patient_Name", patient.Name);
                    cmd.Parameters.AddWithValue("@Email", patient.Email);
                    cmd.Parameters.AddWithValue("@age", patient.Age);
                    cmd.Parameters.AddWithValue("@gender", patient.Gender);
                    cmd.Parameters.AddWithValue("@diagnosis", patient.Diagnosis);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public List<PatientModel> GetAllPatient()
    {
        List<PatientModel> Patients = new List<PatientModel>();

        try
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("GetAllPatient", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            PatientModel patient = new PatientModel();
                            patient.Id = Convert.ToInt32(reader["Patient_Id"]);
                            patient.Name = reader["Patient_Name"].ToString();
                            patient.Email = reader["Email"].ToString();
                            patient.Age = Convert.ToInt32(reader["age"]);
                            patient.Gender = reader["gender"].ToString();
                            patient.Diagnosis = reader["diagnosis"].ToString();

                            Patients.Add(patient);
                        }
                    }
                }
            }
            return Patients;
        }
        catch (Exception ex)
        {
           
            throw;
        }
    }
    

    public PatientModel GetPatientById(int Id)
    {
        using (SqlConnection conn = new SqlConnection(connString))
            try
        {
            conn.Open();
            SqlCommand GetById = new SqlCommand("GetPatient", conn)
            {
                CommandType = CommandType.StoredProcedure,
            };
            GetById.Parameters.AddWithValue("@PatientID", Id);
            SqlDataReader reader = GetById.ExecuteReader();
            if (reader.Read())
            {
                PatientModel Patient = new PatientModel();

                Patient.Id = (int)reader["PatientID"];
                Patient.Name = (string)reader["PatientName"];
                Patient.Email = (string)reader["PatientEmail"];
               
                Patient.Age = (int)reader["PatientAge"];
                Patient.Gender = (string)reader["Gender"];
                    Patient.Diagnosis = (string)reader["Diagnosis"];
               
                return Patient;
            }
            return null;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            conn.Close();
        }
        return null;
    }
    public bool UpdatePatient(PatientModel patient)
    {
        using (SqlConnection conn = new SqlConnection(connString))
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("UpdatePatient", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Patient_Name", patient.Name);
                    cmd.Parameters.AddWithValue("@Email", patient.Email);
                    cmd.Parameters.AddWithValue("@age", patient.Age);
                    cmd.Parameters.AddWithValue("@gender", patient.Gender);
                    cmd.Parameters.AddWithValue("@diagnosis", patient.Diagnosis);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return false;
        }
    }
    public bool DeletePatientById(int id)
    {
        using (SqlConnection conn = new SqlConnection(connString))
            try
        {
            SqlCommand cmd = new SqlCommand("DeletePatient", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PatientId", id);
            conn.Open();
            cmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            conn.Close();
        }
        return false;
    }
}



