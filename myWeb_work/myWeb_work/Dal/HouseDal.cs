using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using myWeb_work.Models;

namespace myWeb_work.Dal
{
    public class HouseDal : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<House>().ToTable("Houses");
        }
        public DbSet<House> Houses { get; set; }
    }
}