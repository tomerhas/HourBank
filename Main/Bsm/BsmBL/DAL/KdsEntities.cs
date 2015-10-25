
using BsmCommon.DataModels;
using BsmCommon.DataModels.Employees;
using BsmCommon.DataModels.Profiles;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BsmBL.DAL
{
    public class KdsEntities : DbContext
    {
        public KdsEntities()
            : base("KDS_CONNECTION")
        {
        }


        public DbSet<Ezor> Ezors { get; set; }
        public DbSet<Oved> Ovdim { get; set; }
        public DbSet<PirteyOved> PirteyOvdim { get; set; }
      
       // public DbSet<Profile> Profiles { get; set; }
       // public DbSet<ProfilesMasachim> ProfileMasachims { get; set; }
       // public DbSet<Masach> Masachs { get; set; }
        public DbSet<Yechida> Yechidot { get; set; }
       

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            string schemaName = ConfigurationManager.AppSettings["KdsOracleSchemaName"];
            modelBuilder.Entity<Ezor>().ToTable("CTB_EZOR", schemaName);
            modelBuilder.Entity<Oved>().ToTable("OVDIM", schemaName);
            modelBuilder.Entity<PirteyOved>().ToTable("PIVOT_PIRTEY_OVDIM", schemaName);
          //  modelBuilder.Entity<Profile>().ToTable("CTB_PROFIL", schemaName);
          //  modelBuilder.Entity<ProfilesMasachim>().ToTable("TB_HARSHAOT_MASACHIM", schemaName);
          //  modelBuilder.Entity<Masach>().ToTable("TB_MASACH", schemaName);
            modelBuilder.Entity<Yechida>().ToTable("CTB_YECHIDA", schemaName);
          

        }
    }
}
