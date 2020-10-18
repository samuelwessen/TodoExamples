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
        {   //är fel password här måste ändra och skapa sqlserver ifall det ska fungera
            optionsBuilder.UseSqlServer(@"");
        }
    }
}
