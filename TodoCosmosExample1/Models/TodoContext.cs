using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using TodoCosmosWithEF.Services;

namespace TodoCosmosWithEF.Models
{
    class TodoContext : DbContext
    {

        public DbSet<Todo> Todos { get; set; }
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
                .Entity<Todo>().HasNoDiscriminator();

        }

    }
}
