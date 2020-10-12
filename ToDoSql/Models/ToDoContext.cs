using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoCodeFirst.Models
{
    public class ToDoContext : DbContext
    {
        public DbSet<ToDo> Todos { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Marcus\Documents\ToDoSqlCodeFirst.mdf;Integrated Security=True;Connect Timeout=30");
        }
    }
}
