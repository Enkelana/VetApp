using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VETAPP.DAL
{
    //KRIJIMI I INTERFACE KRYESOR QE DO PERDORET DHE PER CLASS E TJERA QE DO KRIJOHEN.
    //Perdorimi i generic types pasi te dhenat jane te tipeve te ndryshme.
    //3 funksione do perdoren per te gjitha class --Add--Update--Delete.
    //GetById duhet per te perdorimi i update ku useri do zgjedh ne baze te id se cilin user do beje update.
    //GetAll do perdoret per te krijuar shembull me dictionary dhe per te shfaqur te gjithe userat qe kemi ne databaze.
    public interface IRepository<T>
    where T : class
    {
        List<T> GetAll();
        T GetById(long id);
        void Add(T entity);
        void Update(T entity);
        void Delete(long id);
    }
}
