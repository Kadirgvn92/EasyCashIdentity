using EasyCashIdentity.DataAccessLayer.Abstract;
using EasyCashIdentity.DataAccessLayer.Concrete;
using EasyCashIdentity.DataAccessLayer.Repositories;
using EasyCashIdentity.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashIdentity.DataAccessLayer.EntityFramework;
public class EfCustomerAccountDal : GenericRepository<CustomerAccount>, ICustomerAccountDal
{
    public List<CustomerAccount> GetCustomerAccountList(int id)
    {
        using var context = new Context();
        var values = context.CustomerAccounts.Where(x => x.AppUserID == id).ToList();
        return values;
    }
}
