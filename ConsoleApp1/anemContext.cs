namespace ConsoleApp1
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class anemContext : DbContext
    {
        public anemContext()
            : base("name=anemConnection")
        {
        }

        public virtual DbSet<Demandes> Demandes { get; set; }
        public virtual DbSet<Demandeurs> Demandeurs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Demandes>()
                .Property(e => e.SalaireSouhaite)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Demandeurs>()
                .HasMany(e => e.Demandes)
                .WithRequired(e => e.Demandeurs)
                .WillCascadeOnDelete(false);
        }
    }
}
