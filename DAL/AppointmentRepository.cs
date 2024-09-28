using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VETAPP.Entity;

namespace VETAPP.DAL
{//Ne kete file te DAL kam thirrur te gjitha funksionet nga interface qe i trashegon appointment.
    public class AppointmentRepository : IRepository<Appointment>
    {
        public VetHospitalDatabaseEntities DbContext = new VetHospitalDatabaseEntities();
        //Funksioni getall do marre te gjitha te dhenat nga tabela appointment dhe do i ktheje ne liste

        public List<Appointment> GetAll()
        {
            return DbContext.Appointments.ToList();
        }
        //ky funksion do kerkoje Id qe do kerkoje perdoruesi.

        public Appointment GetById(long id)
        {
            return DbContext.Appointments.Find(id);
        }
        //ky funksion eshte per te shtuar nje appointment te ri dhe ruan ndryshimet.

        public void Add(Appointment appointment)
        {
            DbContext.Appointments.Add(appointment);
            DbContext.SaveChanges();
        }
        //ky funksion eshte per updatimin e te dhenave ne databazes dhe ruan te dhenat.

        public void Update(Appointment appointment)
        {
            DbContext.Entry(appointment).State = System.Data.Entity.EntityState.Modified;
            DbContext.SaveChanges();
        }
        //ky funksion do fshije nje appointment ne baze te id qe vendose perdoruesi.
        //nese ekziston ajo id atehere do beje fshirjen e tij dhe do ruaje te dhenat ne databaze.
        public void Delete(long id)
        {
            Appointment appointment = DbContext.Appointments.Find(id);
            if (appointment != null)
            {
                DbContext.Appointments.Remove(appointment);
                DbContext.SaveChanges();
            }
        }
    }

}
