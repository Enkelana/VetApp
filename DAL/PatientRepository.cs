using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VETAPP.Entity;

namespace VETAPP.DAL
{//Ne kete file te DAL kam thirrur te gjitha funksionet nga interface qe i trashegon patient.

    public class PatientRepository : IRepository<Patient>
    {
        public VetHospitalDatabaseEntities DbContext = new VetHospitalDatabaseEntities();
        //Funksioni getall do marre te gjitha te dhenat nga tabela patient dhe do i ktheje ne liste

        public List<Patient> GetAll()
        {
            return DbContext.Patients.ToList();
        }
        //ky funksion do kerkoje Id qe do kerkoje perdoruesi.

        public Patient GetById(long id)
        {
            return DbContext.Patients.Find(id);
        }
        //ky funksion eshte per te shtuar nje patient te ri dhe ruan ndryshimet.

        public void Add(Patient patient)
        {
            DbContext.Patients.Add(patient);
            DbContext.SaveChanges();
        }
        //ky funksion eshte per updatimin e te dhenave ne databazes dhe ruan te dhenat.

        public void Update(Patient patient)
        {
            DbContext.Entry(patient).State = System.Data.Entity.EntityState.Modified;
            DbContext.SaveChanges();
        }
        //ky funksion do fshije nje patient ne baze te id qe vendose perdoruesi.
        //nese ekziston ajo id atehere do beje fshirjen e tij dhe do ruaje te dhenat ne databaze.
        public void Delete(long id)
        {
            Patient patient = DbContext.Patients.Find(id);
            if (patient != null)
            {
                DbContext.Patients.Remove(patient);
                DbContext.SaveChanges();
            }
        }
    }
}

