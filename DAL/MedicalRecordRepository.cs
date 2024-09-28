using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VETAPP.Entity;

namespace VETAPP.DAL
{//Ne kete file te DAL kam thirrur te gjitha funksionet nga interface qe i trashegon medical record.
    public class MedicalRecordRepository : IRepository<MedicalRecord>
    {
        public VetHospitalDatabaseEntities DbContext = new VetHospitalDatabaseEntities();
        //Funksioni getall do marre te gjitha te dhenat nga tabela medical record dhe do i ktheje ne liste
        public List<MedicalRecord> GetAll()
        {
            return DbContext.MedicalRecords.ToList();
        }
        //ky funksion do kerkoje Id qe do kerkoje perdoruesi.
        public MedicalRecord GetById(long id)
        {
            return DbContext.MedicalRecords.Find(id);
        }

        //ky funksion eshte per te shtuar nje medicalrecord te ri dhe ruan ndryshimet.
        public void Add(MedicalRecord medicalRecord)
        {
            DbContext.MedicalRecords.Add(medicalRecord);
            DbContext.SaveChanges();
        }
        //ky funksion eshte per updatimin e te dhenave ne databazes dhe ruan te dhenat.
        public void Update(MedicalRecord medicalRecord)
        {
            DbContext.Entry(medicalRecord).State = System.Data.Entity.EntityState.Modified;
            DbContext.SaveChanges();
        }
        //ky funksion do fshije nje medicalrecord ne baze te id qe vendose perdoruesi.
        //nese ekziston ajo id atehere do beje fshirjen e tij dhe do ruaje te dhenat ne databaze.
        public void Delete(long id)
        {
            MedicalRecord medicalRecord = DbContext.MedicalRecords.Find(id);
            if (medicalRecord != null)
            {
                DbContext.MedicalRecords.Remove(medicalRecord);
                DbContext.SaveChanges();
            }
        }
    }
}


