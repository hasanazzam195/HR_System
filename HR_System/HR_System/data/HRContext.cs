using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HR_System.data
{
    public class HRContext: IdentityDbContext
    {
        private readonly IConfiguration configuration;

        public HRContext()
        {

        }

        public HRContext(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public DbSet<Employee> employees { get; set; }
        public DbSet<Department> departments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("HRConnection"));
            base.OnConfiguring(optionsBuilder);
        }
    }
}
