using GemStones.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GemStones.DAL.Entities
{
    public class GemsDbContext : DbContext
    {
        public GemsDbContext() : base(@"data source=PC-FRRDIP22G24A\SQLEXPRESS;Initial Catalog=Gems;Integrated Security=True;")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<GemsDbContext, GemStones.DAL.Migrations.Configuration>());
        }

        public DbSet<ProductEntity> Products { get; set; }


        public GemsDbContext(string connectionString) : base(connectionString)
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<HumanContext, EntityFramework_DZConsoleApp.Migrations.Configuration>());
            Configuration.LazyLoadingEnabled = false;
        }

        private static GemsDbContext instance;

        public static GemsDbContext GetInstance()
        {
            if (instance == null)
            {
                instance = new GemsDbContext();
            }

            return instance;
        }
    }
}
