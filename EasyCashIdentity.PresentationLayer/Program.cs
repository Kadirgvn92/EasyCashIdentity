using EasyCashIdentity.BusinessLayer.Abstract;
using EasyCashIdentity.BusinessLayer.Concrete;
using EasyCashIdentity.DataAccessLayer.Abstract;
using EasyCashIdentity.DataAccessLayer.Concrete;
using EasyCashIdentity.DataAccessLayer.EntityFramework;
using EasyCashIdentity.EntityLayer.Concrete;
using EasyCashIdentity.PresentationLayer.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<Context>();
builder.Services.AddIdentity<AppUser,AppRole>().AddEntityFrameworkStores<Context>().AddErrorDescriber<CustomIdentityValidator>();

builder.Services.AddScoped<ICustomerAccountProcessDal, EfCustomerAccountProcessDal>();
builder.Services.AddScoped<ICustomerAccountProcessService, CustomerAccountProcessManager>();

builder.Services.AddScoped<ICustomerAccountDal, EfCustomerAccountDal>();
builder.Services.AddScoped<ICustomerAccountService, CustomerAccountManager>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
