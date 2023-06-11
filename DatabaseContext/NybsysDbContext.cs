using Microsoft.EntityFrameworkCore;
using Nybsys.EntityModels;
using Nybsys.EntityModels.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseContext
{
    public class NybsysDbContext : DbContext
    {
        public NybsysDbContext(DbContextOptions<NybsysDbContext> options) : base(options)
        {

        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer("Server=DESKTOP-5TQKBFB\\SQLEXPRESS;Database=TestDb;Trusted_Connection=True");
        //    }

        //}
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeT> EmployeeTs { get;set; }
        public DbSet<EDesignation> EDesignations { get;set; }
        public DbSet<User> Users { get;set; }


    }
}
