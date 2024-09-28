using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VETAPP.DAL;
using VETAPP.Entity;

namespace VETAPP.BAL
{//Ky eshte file BAL per MedicalRecord dhe do permbaje llogjiken e funksioneve qe jane thirrur ne DAL per MedicalRecord.
    public class MedicalRecordService
    {
        public IRepository<MedicalRecord> medical_RecordRepository;

        public MedicalRecordService(IRepository<MedicalRecord> medicalRecordRepository)
        {
            medical_RecordRepository = medicalRecordRepository;
        }
        //Thirret funksioni GetAllMedicalRecords ku do realizohet perdorimi i 
        //llogjikes se GetAll per kthimin e te gjitha te dhenat nga MedicalRecord.
        public List<MedicalRecord> GetAllMedicalRecords()
        {
            return medical_RecordRepository.GetAll();
        }
        //Thirret funksioni GetMedicalRecordById qe do kerkoje Id qe do kerkoje perdoruesi ku do realizohet perdorimi i getbyid qe eshte krijuar ne DAL file. 

        public MedicalRecord GetMedicalRecordById(long id)
        {//perdorimi i try catch ne rast se ka error ne kthimin e MedicalRecord me id perkatese.
            try
            {
                return medical_RecordRepository.GetById(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving medical record by id: {ex.Message}");
                return null;
            }
        }
        //Llogjika e krijimit te nje MedicalRecord te ri ne databaze.Funksioni ka paramentra te gjitha rreshtat qe kam krijuar ne tabelen MedicalRecord ne sql.

        public void CreateMedicalRecord(long patientId, long? medicationId, int diagnosis, string treatmentDescription)
        {//Krijimi i konstruktoreve per parametrat me lart.
            MedicalRecord newMedicalRecord = new MedicalRecord
            {
                PatientId = patientId,
                MedicationId = medicationId,
                Diagnosis = diagnosis,
                TreatmentDescription = treatmentDescription
            };
            //Perdorimi i funksionit Add nga interface qe trashegon per te shtuar kete MedicalRecord te ri qe krijuam.

            medical_RecordRepository.Add(newMedicalRecord);
        }
        //Llogjika e updatimit te nje MedicalRecord te ri ne databaze.Funksioni ka paramentra te gjitha rreshtat qe kam krijuar ne tabelen MedicalRecord ne sql.

        public void UpdateMedicalRecord(long id, long patientId, long? medicationId, int diagnosis, string treatmentDescription)
        {////Perdorimi i funksionit GetById nga interface qe trashegon per te kerkuar kete MedicalRecord me id perkatese .
            ///Nese ekziston si id atehere behen ndryshime ne rreshtat e MedicalRecord.
            MedicalRecord medicalRecord = medical_RecordRepository.GetById(id);
            if (medicalRecord != null)
            {
                medicalRecord.PatientId = patientId;
                medicalRecord.MedicationId = medicationId;
                medicalRecord.Diagnosis = diagnosis;
                medicalRecord.TreatmentDescription = treatmentDescription;
                //Perdorimi i funksionit Update nga interface qe trashegon MedicalRecord.

                medical_RecordRepository.Update(medicalRecord);
            }
        }
        //Llogjika e fshirjes te nje MedicalRecord ekzistues ne databaze.Funksioni ka paramenter id e MedicalRecord.

        public void DeleteMedicalRecord(long id)
        {//Perdorimi i funksionit Delete nga interface qe trashegon MedicalRecord.
            medical_RecordRepository.Delete(id);
        }
        // Shembull perdorimi i LINQ query dhe dictionary qe kthen medications me key value pair (id-TreatmentDescription).

        public Dictionary<long, string> GetMedicalRecordDictionary()
        {//Perdorimi i funksionit getall nga interface qe trashegon medication.
            List<MedicalRecord> medicalRecords = medical_RecordRepository.GetAll();
            return medicalRecords.ToDictionary(record => record.RecordId, record => record.TreatmentDescription);
        }
        // Shembull i perdorimit te foreach ku do printoje te gjithe MedicalRecord e regjistruar ne databaze.

        public void PrintAllMedicalRecords()
        {//Perdorimi i funksionit getall nga interface qe trashegon medication.
            List<MedicalRecord> medicalRecords = medical_RecordRepository.GetAll();
            foreach (var record in medicalRecords)
            {
                Console.WriteLine($"Record: {record.RecordId}, Diagnosis: {record.Diagnosis}, Treatment: {record.TreatmentDescription}");
            }
        }
    }

}
