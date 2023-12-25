using EasyCashIdentity.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EasyCashIdentity.DataAccessLayer.Concrete;
public class Context : IdentityDbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("server=DESKTOP-A6C5CRN\\SQLEXPRESS;initial catalog=EasyCashDb;integrated Security=true");
    }
    public DbSet<CustomerAccount> CustomerAccounts { get; set; }
    public DbSet<CustomerAccountProcess> CustomerAccountProcesses { get; set; }

}
