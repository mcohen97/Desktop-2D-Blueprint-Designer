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
        public DbSet<BlueprintEntity> Blueprints { get; set; }
        public DbSet<OpeningEntity> Openings { get; set; }
        public DbSet<OpeningTemplateEntity> OpeningTemplates { get; set; }
        public DbSet<WallEntity> Walls { get; set; }
        public DbSet<ColumnEntity> Columns { get; set; }
        public DbSet<SignatureEntity> Signatures { get; set; }
        public DbSet<CostPriceEntity> CostsAndPrices { get; set; }

        public BlueBuilderDBContext() : base("name=BlueBuilderDBContext")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserEntity>().Property(u => u.RegistrationDate).HasColumnType("datetime2");
            modelBuilder.Entity<UserEntity>().Property(u => u.LastLoginDate).HasColumnType("datetime2");
            modelBuilder.Entity<SignatureEntity>().Property(s => s.SignatureDate).HasColumnType("datetime2");

            modelBuilder.Entity<UserEntity>().Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<WallEntity>().Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<OpeningEntity>().Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<OpeningTemplateEntity>().Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<ColumnEntity>().Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<CostPriceEntity>().Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<SignatureEntity>().Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<UserEntity>().Property(x => x.UserName).HasColumnType("VARCHAR");
            modelBuilder.Entity<UserEntity>().Property(x => x.UserName).HasMaxLength(100);
            modelBuilder.Entity<UserEntity>().HasKey<string>(x => x.UserName);
            modelBuilder.Entity<UserEntity>().HasIndex(ue => ue.UserName).IsUnique();
            modelBuilder.Entity<BlueprintEntity>().HasIndex(be => be.Id).IsUnique();

            modelBuilder.Entity<OpeningTemplateEntity>().HasKey<string>(x => x.Name);
            modelBuilder.Entity<OpeningTemplateEntity>().HasIndex(x => x.Name).IsUnique();

            modelBuilder.Entity<BlueprintEntity>().HasRequired<UserEntity>(bp => bp.Owner);
            modelBuilder.Entity<WallEntity>().HasRequired<BlueprintEntity>(we => we.BearerBlueprint);
            modelBuilder.Entity<ColumnEntity>().HasRequired<BlueprintEntity>(we => we.BearerBlueprint);
            modelBuilder.Entity<OpeningEntity>().HasRequired<BlueprintEntity>(we => we.BearerBlueprint);
            modelBuilder.Entity<OpeningEntity>().HasRequired<OpeningTemplateEntity>(oe => oe.Template);


            modelBuilder.Entity<SignatureEntity>().HasIndex(se => se.Id).IsUnique();
            modelBuilder.Entity<SignatureEntity>().HasRequired<BlueprintEntity>(se => se.BlueprintSigned);

        }
    }
}
