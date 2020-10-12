using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using Microsoft.IdentityModel.Protocols;
using Microsoft.Data.SqlClient;

namespace ToDoAzureSqlCodeFirst.Models
{
    public class TodoContext : DbContext
    {
        public DbSet<ToDo> Todos { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(System.ConfigurationManager.AppSettings["SqlConnection"]);
        }
    }
}
