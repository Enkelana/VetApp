using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VETAPP.DAL;
using VETAPP.Entity;

namespace VETAPP.BAL
{//Ky eshte file BAL per Patient dhe do permbaje llogjiken e funksioneve qe jane thirrur ne DAL per patients.
    public class PatientService
    {
        public IRepository<Patient> patient_Repository;

        public PatientService(IRepository<Patient> patientRepository)
        {
            patient_Repository = patientRepository;
        }
        //Thirret funksioni GetAllPatients ku do realizohet perdorimi i 
        //llogjikes se GetAll per kthimin e te gjitha te dhenat nga patients.
        public List<Patient> GetAllPatients()
        {
            return patient_Repository.GetAll();
        }
        //Thirret funksioni GetPatientById qe do kerkoje Id qe do kerkoje patient ku do realizohet perdorimi i getbyid qe eshte krijuar ne DAL file. 

        public Patient GetPatientById(long id)
        { //perdorimi i try catch ne rast se ka error ne kthimin e patient me id perkatese.
            try
            {
                return patient_Repository.GetById(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving patient by id: {ex.Message}");
                return null;
            }
        }
        //Llogjika e krijimit te nje patient te ri ne databaze.Funksioni ka paramentra te gjitha rreshtat qe kam krijuar ne tabelen patient ne sql.
        public void CreatePatient(string patientName, int age, int weight, string species, long userId)
        {
            //Krijimi i konstruktoreve per parametrat me lart.
            Patient newPatient = new Patient
            {
                PatientName = patientName,
                Age = age,
                Weight = weight,
                Species = species,
                UserId = userId
            };
            //Perdorimi i funksionit Add nga interface qe trashegon per te shtuar kete patient te ri qe krijuam.

            patient_Repository.Add(newPatient);
        }
        //Llogjika e updatimit te nje patient te ri ne databaze.Funksioni ka paramentra te gjitha rreshtat qe kam krijuar ne tabelen patient ne sql.

        public void UpdatePatient(long id, string patientName, int age, int weight, string species, long userId)
        {   ////Perdorimi i funksionit GetById nga interface qe trashegon per te kerkuar kete patient me id perkatese .
            ///Nese ekziston si id atehere behen ndryshime ne rreshtat e patient.

            Patient patient = patient_Repository.GetById(id);
            if (patient != null)
            {
                patient.PatientName = patientName;
                patient.Age = age;
                patient.Weight = weight;
                patient.Species = species;
                patient.UserId = userId;
                //Perdorimi i funksionit Update nga interface qe trashegon patient.

                patient_Repository.Update(patient);
            }
        }
        //Llogjika e fshirjes te nje patient ekzistues ne databaze.Funksioni ka paramenter id e patient.

        public void DeletePatient(long id)
        {//Perdorimi i funksionit Delete nga interface qe trashegon patient.
            patient_Repository.Delete(id);
        }
        // Shembull perdorimi i LINQ query dhe dictionary qe kthen patients me key value pair (id-patient_name).

        public Dictionary<long, string> GetPatientDictionary()
        {            //Perdorimi i funksionit getall nga interface qe trashegon patient.
            List<Patient> patients = patient_Repository.GetAll();
            return patients.ToDictionary(patient => patient.PatientId, patient => patient.PatientName);
        }
        // Shembull i perdorimit te foreach ku do printoje te gjithe patients e regjistruar ne databaze.

        public void PrintAllPatients()
        {//Perdorimi i funksionit getall nga interface qe trashegon patients.
            List<Patient> patients = patient_Repository.GetAll();
            foreach (var patient in patients)
            {
                Console.WriteLine($"Patient: {patient.PatientName}, Age: {patient.Age}, Weight: {patient.Weight}");
            }
        }
    }
}
