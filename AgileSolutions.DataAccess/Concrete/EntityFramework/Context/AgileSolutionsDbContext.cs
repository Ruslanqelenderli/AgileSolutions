using AgileSolutions.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileSolutions.DataAccess.Concrete.EntityFramework.Context
{
    public class AgileSolutionsDbContext:DbContext
    {
        public AgileSolutionsDbContext()
        {

        }
        public AgileSolutionsDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                connectionString: @"Server=DESKTOP-2A4NBF1;Database=AgileSolutionsDb;Trusted_Connection=True;Connect Timeout=40;MultipleActiveResultSets=True;"
                );



        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>()
                .HasOne(q => q.Department)
                .WithMany(x => x.Employees)
                .HasForeignKey(x => x.DepartmentId);

            modelBuilder.Entity<Department>().HasData(
                new Department() { Id = 1, Name = "Information Technology", State = true, CreatedDate = DateTime.Now },
                new Department() { Id = 2, Name = "Human Resource", State = true, CreatedDate = DateTime.Now }
                ); ;
            modelBuilder.Entity<Employee>().HasData(
                new Employee() { Id = 1, Name = "Ruslan", Surname = "Galandarli",Email="ruslan.galandarli@gmail.com", State = true, CreatedDate = DateTime.Now, DepartmentId = 1 },
                new Employee() { Id = 2, Name = "Aslan",Surname="Musayev", Email = "aslan.musayev@gmail.com", State = true, IsDeleted = false, CreatedDate = DateTime.Now, DepartmentId = 2 }

                );



        }
    }
}
