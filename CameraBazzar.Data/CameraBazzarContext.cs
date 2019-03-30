using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;
using System.Linq;
using CameraBazzar.Models.EntityModels;
using CameraBazar.Models.Models;

namespace CameraBazzar.Data
{
    public class CameraBazzarContext : IdentityDbContext<ApplicationUser>
    {
        // Your context has been configured to use a 'CameraBazzarContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'CameraBazzar.Data.CameraBazzarContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'CameraBazzarContext' 
        // connection string in the application configuration file.
        public CameraBazzarContext()
            : base("data source=SPASOV;initial catalog=CameraBazzar.Data.CameraBazzarContext;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework")
        {
        }

        public static CameraBazzarContext Create()
        {
            return new CameraBazzarContext();
        }
        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; } 
        public DbSet<Camera> Cameras { get; set; }

       // public System.Data.Entity.DbSet<CameraBazzar.Models.EntityModels.ApplicationUser> ApplicationUsers { get; set; }

        //public System.Data.Entity.DbSet<CameraBazzar.Models.EntityModels.ApplicationUser> ApplicationUsers { get; set; }

        //public DbSet<Login> Logins { get; set; }


        //public DbSet<ApplicationUser> Users1 { get; set; }

        //public System.Data.Entity.DbSet<CameraBazzar.Models.EntityModels.ApplicationUser> ApplicationUsers { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}