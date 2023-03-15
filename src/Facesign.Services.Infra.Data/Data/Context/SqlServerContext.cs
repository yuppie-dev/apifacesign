using Facesign.Services.Infra.Data.Data.Client;
using Facesign.Services.Infra.Data.Data.User;
using Facesign.Services.Infra.Data.Data.Signature;
using Microsoft.EntityFrameworkCore;
using Facesign.Services.Infra.Data.Data.SingleSignOn;

namespace Facesign.Services.Infra.Data.Data.Context
{
    public class SqlServerContext : DbContext
    {
        public SqlServerContext(DbContextOptions<SqlServerContext> options) : base(options) { }
        public DbSet<ClientsData> Clients { get; set; }      
        public DbSet<Clients_FunctionalitiesData> Clients_Functionalities { get; set; }
        public DbSet<Clients_LayoutsData> Clients_Layouts { get; set; }
        public DbSet<UserData> User { get; set; }
        public DbSet<SSOData> SSOs { get; set; }
        public DbSet<SignaturesData> Signatures { get; set; }       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Clients
            modelBuilder.Entity<ClientsData>()
                .Property(b => b.date_insert)
                .HasDefaultValueSql("dateadd(year,1,Getdate())");

            modelBuilder.Entity<ClientsData>()
                .Property(b => b.id)
                .HasDefaultValueSql("NEWID()");
            #endregion

            #region User
            modelBuilder.Entity<UserData>()
                .Property(b => b.date_insert)
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<UserData>()
                .Property(b => b.id)
                .HasDefaultValueSql("NEWID()");
            #endregion

            #region SSO

            modelBuilder.Entity<SSOData>()
               .Property(b => b.date_insert)
               .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<SSOData>()
                .Property(b => b.id)
                .HasDefaultValueSql("NEWID()");

            #endregion

            #region Clients_Functionalities
            modelBuilder.Entity<Clients_FunctionalitiesData>()
                .Property(b => b.date_insert)
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Clients_FunctionalitiesData>()
                .Property(b => b.id)
                .HasDefaultValueSql("NEWID()");
            #endregion

            #region Clients_Layouts

            modelBuilder.Entity<Clients_LayoutsData>()
                .Property(b => b.date_insert)
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Clients_LayoutsData>()
                .Property(b => b.id)
                .HasDefaultValueSql("NEWID()");

            #endregion

            #region Signatures
            
            modelBuilder.Entity<SignaturesData>()
                .Property(b => b.id)
                .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<SignaturesData>()
                .Property(b => b.date_insert)
                .HasDefaultValueSql("getdate()");

            #endregion         

        }
    }
}
