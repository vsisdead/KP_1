namespace Test3.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<DOCTOR> DOCTOR { get; set; }
        public virtual DbSet<OSMOTR> OSMOTR { get; set; }
        public virtual DbSet<SOSTAV> SOSTAV { get; set; }
        public virtual DbSet<SPORTSMENS> SPORTSMENS { get; set; }
        public virtual DbSet<TRENER> TRENER { get; set; }
        public virtual DbSet<TRENEROVKA> TRENEROVKA { get; set; }
        public virtual DbSet<USERS> USERS { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OSMOTR>()
                .HasMany(e => e.DOCTOR)
                .WithRequired(e => e.OSMOTR)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TRENEROVKA>()
                .HasMany(e => e.TRENER)
                .WithRequired(e => e.TRENEROVKA)
                .WillCascadeOnDelete(false);
        }
    }
}
