using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace TodoCosmosWithEF.Models
{
    public class TodoContext : DbContext
    {
        public DbSet<ToDo> ToDos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseCosmos(
                ConfigurationManager.AppSettings["EndpointUri"],
                ConfigurationManager.AppSettings["PrimaryKey"],
                databaseName: ConfigurationManager.AppSettings["DatabaseName"]
            );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasDefaultContainer(ConfigurationManager.AppSettings["ContainerName"])
                .Entity<ToDo>().HasNoDiscriminator();
        }
    }
}
