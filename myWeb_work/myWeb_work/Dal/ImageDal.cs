using myWeb_work.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace myWeb_work.Dal
{
    public class ImageDal : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Image>().ToTable("Images");
        }
        public DbSet<Image> Images { get; set; }
    }
}