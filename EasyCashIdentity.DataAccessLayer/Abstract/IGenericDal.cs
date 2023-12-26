using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashIdentity.DataAccessLayer.Abstract;
public interface IGenericDal<T> where T : class
{
    void Insert(T entity);
    void Delete(T entity);
    void Update(T entity);
    T GetByID (int id);
    List<T> GetList();
}
