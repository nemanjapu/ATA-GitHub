using ATAarhitektonskiStudio.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace ATAarhitektonskiStudio.DAL
{
    public class databaseContext : DbContext
    {
        public databaseContext() : base("name=conString")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<databaseContext, Migrations.Configuration>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
        public DbSet<User> User { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<Blog> Blog { get; set; }
        public DbSet<Global> Global { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<ProjectImages> ProjectImages { get; set; }
    }
}