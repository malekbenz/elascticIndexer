namespace RedIndexer.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class FNE : DbContext
    {
        public FNE()
            : base("name=FNE")
        {
            this.Database.CommandTimeout = 180;

        }


        public virtual DbSet<Demandeurs> Demandeurs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Demandeurs>()
                .Property(e => e.id)
                .IsUnicode(false);

        
        }
    }
}
