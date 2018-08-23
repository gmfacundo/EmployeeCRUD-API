using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using EmployeeAPI.Models;
using System.Linq;

namespace EmployeeAPI
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<EmployeeContext>(opt =>
                opt.UseInMemoryDatabase("EmployeeList"));
            services.AddMvc()
                    .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        public void Configure(IApplicationBuilder app, EmployeeContext context)
        {
            app.UseDefaultFiles();
            app.UseStaticFiles();

            SeedDB(context);

            app.UseMvc();
        }

        public void SeedDB(EmployeeContext context)
        {

            if (context.EmployeeItems.Count() == 0)
            {
                context.EmployeeItems.Add(new EmployeeItem
                {
                    Name = "Drake",
                    Lastn = "Ramoray",
                    Age = 35,
                    EntryDate = "2014-05-16",
                    Area = "Human Resources",
                    Role = "Manager"
                });
                context.SaveChanges();
            }
        }

    }
}