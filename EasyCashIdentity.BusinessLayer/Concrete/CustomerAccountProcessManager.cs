using EasyCashIdentity.BusinessLayer.Abstract;
using EasyCashIdentity.DataAccessLayer.Abstract;
using EasyCashIdentity.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashIdentity.BusinessLayer.Concrete;
public class CustomerAccountProcessManager : ICustomerAccountProcessService
{
    private readonly ICustomerAccountProcessDal _customerAccountProcessDal;

    public CustomerAccountProcessManager(ICustomerAccountProcessDal customerAccountProcessDal)
    {
        _customerAccountProcessDal = customerAccountProcessDal;
    }

    public void TDelete(CustomerAccountProcess t)
    {
        _customerAccountProcessDal.Delete(t);
    }

    public CustomerAccountProcess TGetByID(int id)
    {
        return _customerAccountProcessDal.GetByID(id);
    }

    public List<CustomerAccountProcess> TGetList()
    {
       return _customerAccountProcessDal.GetList();
    }

    public void TInsert(CustomerAccountProcess Entity)
    {
       _customerAccountProcessDal.Insert(Entity);
    }

    public List<CustomerAccountProcess> TMyLastProcess(int id)
    {
        return _customerAccountProcessDal.MyLastProcess(id);

    }

    public void TUpdate(CustomerAccountProcess Entity)
    {
        _customerAccountProcessDal.Update(Entity);
    }
}
