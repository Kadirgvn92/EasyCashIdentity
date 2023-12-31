using EasyCashIdentity.BusinessLayer.Abstract;
using EasyCashIdentity.DataAccessLayer.Abstract;
using EasyCashIdentity.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashIdentity.BusinessLayer.Concrete;
public class CustomerAccountManager : ICustomerAccountService
{
    private readonly ICustomerAccountDal _customerAccountDal;

    public CustomerAccountManager(ICustomerAccountDal customerAccountDal)
    {
        _customerAccountDal = customerAccountDal;
    }

    public void TDelete(CustomerAccount Entity)
    {
       _customerAccountDal.Delete(Entity);
    }

    public CustomerAccount TGetByID(int id)
    {
       return _customerAccountDal.GetByID(id);
    }

    public List<CustomerAccount> TGetCustomerAccountList(int id)
    {
        return _customerAccountDal.GetCustomerAccountList(id);
    }

    public List<CustomerAccount> TGetList()
    {
       return _customerAccountDal.GetList();
    }

    public void TInsert(CustomerAccount Entity)
    {
        _customerAccountDal.Insert(Entity);
    }

    public void TUpdate(CustomerAccount Entity)
    {
        _customerAccountDal.Update(Entity);
    }
}
