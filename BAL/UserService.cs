using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VETAPP.DAL;
using VETAPP.Entity;

namespace VETAPP.BAL
{     //Ky eshte file BAL per User dhe do permbaje llogjiken e funksioneve qe jane thirrur ne DAL per users.
    public class UserService
    {
        public IRepository<User> user_Repository;

        public UserService(IRepository<User> userRepository)
        {
            user_Repository = userRepository;
        }
        //Thirret funksioni GetAllUsers ku do realizohet perdorimi i 
        //llogjikes se GetAll per kthimin e te gjitha te dhenat nga users.
        public List<User> GetAllUsers()
        {
            return user_Repository.GetAll();
        }
        //Thirret funksioni Getuserbyid qe do kerkoje Id qe do kerkoje useri ku do realizohet perdorimi i getbyid qe eshte krijuar ne DAL file. 
        public User GetUserById(long id)
        {   //perdorimi i try catch ne rast se ka error ne kthimin e userit me id perkatese.
            try
            {
                return user_Repository.GetById(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"There was an error finding user by id: {ex.Message}");
                return null;
            }
        }
        //Llogjika e krijimit te nje useri te ri ne databaze.Funksioni ka paramentra te gjitha rreshtat qe kam krijuar ne tabelen user ne sql.
        public void CreateUser(string userName, string email, string password, long userType)
        {
            //Krijimi i konstruktoreve per parametrat me lart.
            User newUser = new User
            {
                UserName = userName,
                Email = email,
                Password = password,
                UserType = userType
            };
            //Perdorimi i funksionit Add nga interface qe trashegon per te shtuar kete user te ri qe krijuam.
            user_Repository.Add(newUser);
        }
        //Llogjika e updatimit te nje useri te ri ne databaze.Funksioni ka paramentra te gjitha rreshtat qe kam krijuar ne tabelen user ne sql.
        public void UpdateUser(long id, string userName, string email, string password, long userType)
        {
            ////Perdorimi i funksionit GetById nga interface qe trashegon per te kerkuar kete user me id perkatese .
            ///Nese ekziston si id atehere behen ndryshime ne rreshtat e userit.
           
            User user = user_Repository.GetById(id);
            if (user != null)
            {
                user.UserName = userName;
                user.Email = email;
                user.Password = password;
                user.UserType = userType;
                //Perdorimi i funksionit Update nga interface qe trashegon users.
                user_Repository.Update(user);
            }
        }
        //Llogjika e fshirjes te nje useri ekzistues ne databaze.Funksioni ka paramenter id e userit.
        public void DeleteUser(long id)
        { //Perdorimi i funksionit Delete nga interface qe trashegon users.
            user_Repository.Delete(id);
        }
        // Shembull perdorimi i LINQ query dhe dictionary qe kthen userat me key value pair (id-username).
        public Dictionary<long, string> GetUserDictionary()
        {
            //Perdorimi i funksionit getall nga interface qe trashegon users.
            List<User> users = user_Repository.GetAll();
            return users.ToDictionary(user => user.UserId, user => user.UserName);
        }
        // Shembull i perdorimit te foreach dhe if/else ku do printoje te gjithe userat e regjistruar ne databze.
        public void PrintAllUsers()
        {  //Perdorimi i funksionit getall nga interface qe trashegon users.
            List<User> users = user_Repository.GetAll();
            foreach (User user in users)
            {
                // Kam marr qe id=3 e ka admini dhe id e tjera jane te gjith perdoruesit e tjere.
                if (user.UserType == 3)
                {
                    Console.WriteLine($"Admin: {user.UserName}");
                }
                else
                {
                    Console.WriteLine($"User: {user.UserName}");
                }
            }
        }
    }
}
