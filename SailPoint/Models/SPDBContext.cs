using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SailPoint.Models
{
    public class SPDBContext : DbContext
    {
        public SPDBContext(DbContextOptions options)
            :base(options)
        {

        }
        public SPDBContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=data/SailPoint.db");
        public DbSet<Company> Companies { get; set; }
        public DbSet<City> Cities { get; set; }
 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>()
            .HasKey(p => p.Id)
            .HasName("Companies");
            modelBuilder.Entity<Company>()
            .Property(p => p.Id)
            .ValueGeneratedOnAdd()
            .IsRequired();

            modelBuilder.Entity<Company>().HasData(new Company[]
            {
            // movies
            new Company {Id = 1, Name = "xyz", Url = "https://xyz.com/MainPage"},
            new Company {Id = 2 , Name = "yyy", Url = "https://yyy.com/MainPage"},
            });
            var rows = new List<City>();
 
            // Read the strings from the text file
            string[] lines = File.ReadAllLines("C:\\Users\\Public\\temp\\world-cities.txt");

            // Insert the strings into the database
            int i = 1;
            foreach (string line in lines)
            {
                rows.Add(new City { Id = i++, Code = i.ToString(), Name = line });
            }

            // Close the connection to the database
            
            //for (int i = 1; i < 25; i++)
            //{
            //    rows.Add(new City {Id = i, Code = "US"+i.ToString(), Name = "United States "+i.ToString() });

            //}

            modelBuilder.Entity<City>().HasData(rows);
 
            base.OnModelCreating(modelBuilder);
        }
    }
}
