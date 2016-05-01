using BsmCommon.DataModels;
using BsmCommon.DataModels.Budgets;
using BsmCommon.DataModels.Changes;
using BsmCommon.DataModels.Employees;
using BsmCommon.DataModels.Profiles;
using InfrastructureLogs.Logs.DataModels;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BsmBL.DAL
{
    public class BsmEntities : DbContext 
    {
        public BsmEntities() : base("BSM_CONNECTION")
            //: base(new OracleConnection(ConfigurationManager.ConnectionStrings["BSM_CONNECTION"].ConnectionString), true) 
        { 
        }

        public DbSet<Parameter> Parameters { get; set; }
        public DbSet<Budget> Budgets { get; set; }
        public DbSet<BudgetChange> BudgetChanges { get; set; }

        public DbSet<BudgetEmployee> Employees { get; set; }
        public DbSet<Harshaa> HarshaotOvdim { get; set; }
        public DbSet<Masach> Mashacim { get; set; }
        public DbSet<HarshaatMasach> HarshaatMasach { get; set; }
        public DbSet<BudgetSpecial> BudgetSpecial { get; set; }
        public DbSet<BudgetSpecialYechida> BudgetSpecialYechida { get; set; }
        public DbSet<LogItem> Logs { get; set; }
     
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            string schemaName = ConfigurationManager.AppSettings["BsmOracleSchemaName"];
            modelBuilder.Entity<Parameter>().ToTable("TB_PARAMETERIM", schemaName);
            modelBuilder.Entity<Budget>().ToTable("TB_BUDGET", schemaName);
            modelBuilder.Entity<BudgetChange>().ToTable("TB_BUDGET_CHANGE", schemaName);
            modelBuilder.Entity<BudgetEmployee>().ToTable("TB_BUDGET_EMPLOYEES", schemaName);
            modelBuilder.Entity<Harshaa>().ToTable("TB_HARSHAA", schemaName);
            modelBuilder.Entity<Masach>().ToTable("TB_MASACH", schemaName);
            modelBuilder.Entity<HarshaatMasach>().ToTable("TB_HARSHAOT_MASACH", schemaName);
            modelBuilder.Entity<BudgetSpecial>().ToTable("TB_BUDGET_SPECIAL", schemaName);
            modelBuilder.Entity<BudgetSpecialYechida>().ToTable("TB_BUDGET_SPECIAL_YECHIDA", schemaName);
            modelBuilder.Entity<LogItem>().ToTable("TB_LOG", schemaName);
        }
    }
}
