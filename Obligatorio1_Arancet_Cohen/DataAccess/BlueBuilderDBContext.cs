using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess
{
    public class BlueBuilderDBContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }

        public BlueBuilderDBContext() : base("name=BlueBuilderDBContext")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserEntity>().Property(u => u.RegistrationDate).HasColumnType("datetime2");
            modelBuilder.Entity<UserEntity>().Property(u => u.LastLoginDate).HasColumnType("datetime2");
            modelBuilder.Entity<UserEntity>().Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
