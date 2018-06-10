﻿using Entities;
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
        public DbSet<PointEntity> Points { get; set; }
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
            modelBuilder.Entity<BlueprintEntity>().Property(u => u.LastSignDate).HasColumnType("datetime2");
            modelBuilder.Entity<UserEntity>().Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
