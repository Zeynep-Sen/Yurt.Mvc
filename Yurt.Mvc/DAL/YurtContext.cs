using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Yurt.Mvc.Models;

namespace Yurt.Mvc.DAL
{
    public class YurtContext:DbContext 
    {
        public YurtContext() : base("cstr")
        {

        }

        public DbSet<Ogrenci> Ogrenciler { get; set; }
        public DbSet<Okul> Okullar { get; set; }
        public DbSet<Kullanici> Kullanicilar { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Ogrenci>().ToTable("tblOgrenciler");

            modelBuilder.Entity<Ogrenci>().Property(o => o.ad).HasMaxLength(30).IsRequired().HasColumnType("varchar");
            modelBuilder.Entity<Ogrenci>().Property(o => o.soyad).HasMaxLength(25).IsRequired().HasColumnType("varchar");
            modelBuilder.Entity<Ogrenci>().Property(o => o.anneAd).HasMaxLength(30).IsRequired().HasColumnType("varchar");
            modelBuilder.Entity<Ogrenci>().Property(o => o.anneSoyad).HasMaxLength(25).IsRequired().HasColumnType("varchar");
            modelBuilder.Entity<Ogrenci>().Property(o => o.babaAd).HasMaxLength(30).IsRequired().HasColumnType("varchar");
            modelBuilder.Entity<Ogrenci>().Property(o => o.babaSoyad).HasMaxLength(25).IsRequired().HasColumnType("varchar");
            modelBuilder.Entity<Ogrenci>().Property(o => o.okulId).HasColumnType("int");

            modelBuilder.Entity<Okul>().ToTable("tblOkul");

            modelBuilder.Entity<Okul>().Property(o => o.Okul_Ad).HasMaxLength(50).IsRequired().HasColumnType("varchar");

            modelBuilder.Entity<Kullanici>().ToTable("tblKullanici");

            modelBuilder.Entity<Kullanici>().Property(k => k.email).HasMaxLength(30).IsRequired().HasColumnType("varchar");
            modelBuilder.Entity<Kullanici>().Property(k => k.Sifre).HasMaxLength(20).IsRequired().HasColumnType("varchar");




        }
    }
}