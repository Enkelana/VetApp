using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VETAPP.Entity;

namespace VETAPP.DAL
{//Ne kete file te DAL kam thirrur te gjitha funksionet nga interface qe i trashegon medication.
    public class MedicationRepository : IRepository<Medication>
    {
        public VetHospitalDatabaseEntities DbContext = new VetHospitalDatabaseEntities();
        //Funksioni getall do marre te gjitha te dhenat nga tabela medication dhe do i ktheje ne liste

        public List<Medication> GetAll()
        {
            return DbContext.Medications.ToList();
        }
        //ky funksion do kerkoje Id qe do kerkoje perdoruesi.

        public Medication GetById(long id)
        {
            return DbContext.Medications.Find(id);
        }
        //ky funksion eshte per te shtuar nje patient te ri dhe ruan ndryshimet.

        public void Add(Medication medication)
        {
            DbContext.Medications.Add(medication);
            DbContext.SaveChanges();
        }
        //ky funksion eshte per updatimin e te dhenave ne databazes dhe ruan te dhenat.

        public void Update(Medication medication)
        {
            DbContext.Entry(medication).State = System.Data.Entity.EntityState.Modified;
            DbContext.SaveChanges();
        }
        //ky funksion do fshije nje medication ne baze te id qe vendose perdoruesi.
        //nese ekziston ajo id atehere do beje fshirjen e tij dhe do ruaje te dhenat ne databaze.
        public void Delete(long id)
        {
            Medication medication = DbContext.Medications.Find(id);
            if (medication != null)
            {
                DbContext.Medications.Remove(medication);
                DbContext.SaveChanges();
            }
        }
    }
}

