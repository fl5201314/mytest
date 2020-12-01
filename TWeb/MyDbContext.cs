using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TWeb
{
    public class MyDbContext:DbContext
    {
       public DbSet<Person> Persons { get; set; }

        public DbSet<Myclass> Myclasses { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseMySql("Server=127.0.0.1;database=test;uid=root;pwd=123456");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
          var ep =  modelBuilder.Entity<Person>();
            ep.ToTable("t_persons");


      var  mStudent =      modelBuilder.Entity<Student>();
            mStudent.ToTable("t_students");

            mStudent.HasOne(e => e.myclass).WithMany().HasForeignKey(e => e.classId).IsRequired();

            var mmyclass = modelBuilder.Entity<Myclass>();
            mmyclass.ToTable("t_myclass");

        }
    }

    public class Person
    {
        public long Id { get; set; }
        public int Age { get; set; }

        public string Name { get; set; }
    }

    public class Student
    {
        public long Id { get; set; }

        public long classId { get; set; }

        public string Name { get; set; }

        public Myclass myclass { get; set; }
    }

    public class Myclass
    {
        public long Id { get; set; }

        public string Name { get; set; }
    }

}
