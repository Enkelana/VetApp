using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VETAPP.DAL;
using VETAPP.Entity;

namespace VETAPP.BAL
{
    public class BAL
    {//Ky eshte file BAL per StoreProcedure
        public DAL.DAL dal;

        public BAL()
        {
            dal = new DAL.DAL();
        }
        // Metoda per te marr userId nga username per tabelen users
        public long GetUserIdByUsername(string username)
        {
            using (var context = new VetHospitalDatabaseEntities()) 
            {
                var user = context.Users.FirstOrDefault(u => u.UserName == username);

                if (user != null)
                {
                    return user.UserId;
                }
                else
                {
                    return 0; 
                }
            }
        }
        // Metoda per te marr userId nga username per tabelen patient
        public long GetPatientIdByUsername(string username)
        {
            using (var context = new VetHospitalDatabaseEntities()) 
            {
                var patient = context.Patients.FirstOrDefault(p => p.PatientName == username);

                if (patient != null)
                {
                    return patient.PatientId;
                }
                else
                {
                    return 0;
                }
            }
        }

        #region Patient Operations
        // sp GetPatientsByUser me parameter id e userit

        public List<Patient> GetPatientsByUser(long userId)
        {
            try
            {
                return dal.GetPatientsByUser(userId);
            }
            catch (Exception ex)
            {
                throw new Exception("Error in BAL while retrieving patients by user.", ex);
            }
        }

        #endregion

        #region Appointment Operations
        // sp GetAppointmentsByPatient me parameter id e patient
        public List<Appointment> GetAppointmentsByPatient(long patientId)
        {
            try
            {
                return dal.GetAppointmentsByPatient(patientId);
            }
            catch (Exception ex)
            {
                throw new Exception("Error in BAL while retrieving appointments by patient.", ex);
            }
        }

        #endregion

        #region MedicalRecord Operations
        // sp GetMedicalRecordsByPatient me parameter id e patient
        public List<MedicalRecord> GetMedicalRecordsByPatient(long patientId)
        {
            try
            {
                return dal.GetMedicalRecordsByPatient(patientId);
            }
            catch (Exception ex)
            {
                throw new Exception("Error in BAL while retrieving medical records by patient.", ex);
            }
        }

        #endregion
        //Mbyll database connection
        public void Dispose()
        {
            dal.Dispose();
        }
    }
}
