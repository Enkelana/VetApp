using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VETAPP.Entity;

namespace VETAPP.DAL
{//Ky eshte file BAL per Medication dhe do permbaje llogjiken e funksioneve qe jane thirrur ne DAL per medications.
    public class MedicationService
    {
        public IRepository<Medication> medication_Repository;

        public MedicationService(IRepository<Medication> medicationRepository)
        {
            medication_Repository = medicationRepository;
        }
        //Thirret funksioni GetAllMedications ku do realizohet perdorimi i 
        //llogjikes se GetAll per kthimin e te gjitha te dhenat nga medications.
        public List<Medication> GetAllMedications()
        {
            return medication_Repository.GetAll();
        }
        //Thirret funksioni GetMedicationById qe do kerkoje Id qe do kerkoje perdoruesi ku do realizohet perdorimi i getbyid qe eshte krijuar ne DAL file. 

        public Medication GetMedicationById(long id)
        {//perdorimi i try catch ne rast se ka error ne kthimin e medication me id perkatese.
            try
            {
                return medication_Repository.GetById(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving medication by id: {ex.Message}");
                return null;
            }
        }
        //Llogjika e krijimit te nje medication te ri ne databaze.Funksioni ka paramentra te gjitha rreshtat qe kam krijuar ne tabelen medication ne sql.

        public void CreateMedication(string medicationName, string medicationDesc, decimal sellPrice, long quantity, int dosage, decimal purchasePrice)
        {
            Medication newMedication = new Medication
            {            //Krijimi i konstruktoreve per parametrat me lart.

                MedicationName = medicationName,
                MedicationDescription = medicationDesc,
                MedicationSellPrice = sellPrice,
                Quantity = quantity,
                Dosage = dosage,
                MedicationPurchasePrice = purchasePrice
            };
            //Perdorimi i funksionit Add nga interface qe trashegon per te shtuar kete medication te ri qe krijuam.

            medication_Repository.Add(newMedication);
        }
        //Llogjika e updatimit te nje medication te ri ne databaze.Funksioni ka paramentra te gjitha rreshtat qe kam krijuar ne tabelen medication ne sql.

        public void UpdateMedication(long id, string medicationName, string medicationDesc, decimal sellPrice, long quantity, int dosage, decimal purchasePrice)
        { ////Perdorimi i funksionit GetById nga interface qe trashegon per te kerkuar kete medication me id perkatese .
            ///Nese ekziston si id atehere behen ndryshime ne rreshtat e medication.
            Medication medication = medication_Repository.GetById(id);
            if (medication != null)
            {
                medication.MedicationName = medicationName;
                medication.MedicationDescription = medicationDesc;
                medication.MedicationSellPrice = sellPrice;
                medication.Quantity = quantity;
                medication.Dosage = dosage;
                medication.MedicationPurchasePrice = purchasePrice;
                //Perdorimi i funksionit Update nga interface qe trashegon medication.

                medication_Repository.Update(medication);
            }
        }
        //Llogjika e fshirjes te nje medication ekzistues ne databaze.Funksioni ka paramenter id e medicationit.

        public void DeleteMedication(long id)
        {//Perdorimi i funksionit Delete nga interface qe trashegon medication.
            medication_Repository.Delete(id);
        }
        // Shembull perdorimi i LINQ query dhe dictionary qe kthen medications me key value pair (id-MedicationName).

        public Dictionary<long, string> GetMedicationDictionary()
        {        //Perdorimi i funksionit getall nga interface qe trashegon medication.
            List<Medication> medications = medication_Repository.GetAll();
            return medications.ToDictionary(medication => medication.MedicationId, medication => medication.MedicationName);
        }
        // Shembull i perdorimit te foreach ku do printoje te gjithe medications e regjistruar ne databaze.

        public void PrintAllMedications()
        {//Perdorimi i funksionit getall nga interface qe trashegon medication.
            List<Medication> medications = medication_Repository.GetAll();
            foreach (var medication in medications)
            {
                Console.WriteLine($"Medication: {medication.MedicationName}, Dosage: {medication.Dosage}, Quantity: {medication.Quantity}");
            }
        }
    }
}

