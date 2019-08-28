using DCRHAK.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace DCRHAK.DAL
{
    public class DCRHAKContext : DbContext
    {

        public DCRHAKContext() : base("DCRHAKContext")
        {
        }

        public DbSet<Package> Packages { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<Discussion> Discussions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}