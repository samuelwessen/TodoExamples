using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace TodoAzureSqlCodeFirst.Models
{
    public class TodoContext : DbContext
    {
        public DbSet<ToDo> ToDos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=tcp:win20sw-sqlserver.database.windows.net,1433;Initial Catalog=AzureSqlCodeFirstSW;Persist Security Info=False;User ID=SqlAdmin;Password=Sammyman_86;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }
    }
}
