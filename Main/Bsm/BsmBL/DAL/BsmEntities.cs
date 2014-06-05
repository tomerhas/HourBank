using BsmCommon.DataModels;
using BsmCommon.DataModels.Budgets;
using BsmCommon.DataModels.Employees;
using Oracle.DataAccess.Client;
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
        public BsmEntities()
            : base(new OracleConnection(ConfigurationManager.ConnectionStrings["BSM_CONNECTION"].ConnectionString), true) 
        { 
        }

        public DbSet<Parameter> Parameters { get; set; }
        public DbSet<Budget> Budgets { get; set; }
        public DbSet<BudgetChange> BudgetChanges { get; set; }

        public DbSet<BudgetEmployee> Employees { get; set; }
        
  
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            string schemaName = ConfigurationManager.AppSettings["BsmOracleSchemaName"];
            modelBuilder.Entity<Parameter>().ToTable("TB_PARAMETERIM", schemaName);
            modelBuilder.Entity<Budget>().ToTable("TB_BUDGET", schemaName);
            modelBuilder.Entity<BudgetChange>().ToTable("TB_BUDGET_CHANGE", schemaName);
            modelBuilder.Entity<BudgetEmployee>().ToTable("TB_BUDGET_EMPLOYEES", schemaName);
        }
    }
}
