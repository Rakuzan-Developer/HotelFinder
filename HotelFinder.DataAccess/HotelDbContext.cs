using System;
using System.Collections.Generic;
using System.Text;
using HotelFinder.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelFinder.DataAccess
{
    public class HotelDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=LAPTOP-657RCKM3; Database=HotelDb;uid=sas;pwd=1234;");
        }

        public DbSet<Hotel> Hotels { get; set; }
    }
}
