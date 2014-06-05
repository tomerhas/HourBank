
using BsmCommon.DataModels;
using BsmCommon.DataModels.Employees;
using Oracle.DataAccess.Client;
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
            : base(new OracleConnection(ConfigurationManager.ConnectionStrings["KDS_CONNECTION"].ConnectionString), true)
        {
        }


        public DbSet<Ezor> Ezors { get; set; }
        public DbSet<Oved> Ovdim { get; set; }
        public DbSet<PirteyOved> PirteyOvdim { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            string schemaName = ConfigurationManager.AppSettings["KdsOracleSchemaName"];
            modelBuilder.Entity<Ezor>().ToTable("CTB_EZOR", schemaName);
            modelBuilder.Entity<Oved>().ToTable("OVDIM", schemaName);
            modelBuilder.Entity<PirteyOved>().ToTable("PIVOT_PIRTEY_OVDIM", schemaName);
        }
    }
}
