using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VETAPP.Entity;

namespace VETAPP.DAL
{
    //Ne kete file te DAL kam thirrur te gjitha funksionet nga interface qe i trashegon users.

    public class UserRepository : IRepository<User>
    {
        public VetHospitalDatabaseEntities DbContext = new VetHospitalDatabaseEntities();
        //Funksioni getall do marre te gjitha te dhenat nga tabela useri dhe do i ktheje ne liste
        public List<User> GetAll()
        {
            return DbContext.Users.ToList();
        }
        //ky funksion do kerkoje Id qe do kerkoje useri.
        public User GetById(long id)
        {
            return DbContext.Users.Find(id);
        }
        //ky funksion eshte per te shtuar nje user te ri dhe ruan ndryshimet.
        public void Add(User user)
        {
            DbContext.Users.Add(user);
            DbContext.SaveChanges();
        }
        //ky funksion eshte per updatimin e te dhenave ne databazes dhe ruan te dhenat.
        public void Update(User user)
        {
            DbContext.Entry(user).State = System.Data.Entity.EntityState.Modified;
            DbContext.SaveChanges();
        }
        //ky funksion do fshije nje user ne baze te id qe vendose useri
        //nese ekziston ajo id atehere do beje fshirjen e tij dhe do ruaje te dhenat ne databaze.
        public void Delete(long id)
        {
            User user = DbContext.Users.Find(id);
            if (user != null)
            {
                DbContext.Users.Remove(user);
                DbContext.SaveChanges();
            }
        }

    }
}
