﻿using EasyCashIdentity.DataAccessLayer.Abstract;
using EasyCashIdentity.DataAccessLayer.Concrete;
using EasyCashIdentity.DataAccessLayer.Repositories;
using EasyCashIdentity.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashIdentity.DataAccessLayer.EntityFramework;
public class EfCustomerAccountProcessDal : GenericRepository<CustomerAccountProcess>, ICustomerAccountProcessDal
{
    public List<CustomerAccountProcess> MyLastProcess(int id)
    {
        using var context = new Context();
        var values = context.CustomerAccountProcesses.Where(x => x.ReceiverID == id || x.SenderID == id).ToList();
        return values;
    }
}
