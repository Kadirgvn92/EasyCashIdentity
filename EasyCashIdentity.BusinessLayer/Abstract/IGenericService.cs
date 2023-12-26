using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashIdentity.BusinessLayer.Abstract;
public interface IGenericService<T> where T : class
{
    void TInsert(T Entity);
    void TUpdate(T Entity);
    void TDelete(T Entity);
    T TGetByID (int id);
    List<T> TGetList();

}
