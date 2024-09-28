using System;
using System.Collections.Generic;
using System.Linq;
using VETAPP.Entity;

namespace VETAPP.DAL
{
    public class DAL
    {//Ky eshte file DAL per StoreProcedure
        public VetHospitalDatabaseEntities context;

        public DAL()
        {
            context = new VetHospitalDatabaseEntities();
        }

        #region Patient CRUD Operations
        //operationet CRUD per sp e pare GetPatientsByUser
        public List<Patient> GetPatientsByUser(long userId)
        {//vendosja e try catch
            try
            {//perdorimi i LINQ expression
                return context.Patients.Where(p => p.UserId == userId).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving patients.", ex);
            }
        }

        #endregion

        #region Appointment CRUD Operations
        //operationet CRUD per sp e pare GetAppointmentsByPatient
        public List<Appointment> GetAppointmentsByPatient(long patientId)
        {//vendosja e try catch
            try
            {//perdorimi i LINQ expression
                return context.Appointments.Where(a => a.PatientId == patientId).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving appointments.", ex);
            }
        }

        #endregion

        #region MedicalRecord CRUD Operations
        //operationet CRUD per sp e pare GetMedicalRecordsByPatient
        public List<MedicalRecord> GetMedicalRecordsByPatient(long patientId)
        {//vendosja e try catch
            try
            {//perdorimi i LINQ expression
                return context.MedicalRecords.Where(mr => mr.PatientId == patientId).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving medical records.", ex);
            }
        }

        #endregion
        //Mbyll database connection
        public void Dispose()
        {
            context.Dispose();
        }
    }
}
