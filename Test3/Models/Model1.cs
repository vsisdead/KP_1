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
        public virtual DbSet<GROUPS> GROUPS { get; set; }
        public virtual DbSet<OSMOTR> OSMOTR { get; set; }
        public virtual DbSet<SOSTAV> SOSTAV { get; set; }
        public virtual DbSet<SPORTSMENS> SPORTSMENS { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TRENER> TRENER { get; set; }
        public virtual DbSet<TRENEROVKA> TRENEROVKA { get; set; }
        public virtual DbSet<USERS> USERS { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DOCTOR>()
                .Property(e => e.OSMOTR)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<GROUPS>()
                .Property(e => e.SOSTAV)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<GROUPS>()
                .HasMany(e => e.SPORTSMENS)
                .WithRequired(e => e.GROUPS)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OSMOTR>()
                .Property(e => e.OSMOTR1)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<OSMOTR>()
                .Property(e => e.SOSTAV)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<OSMOTR>()
                .HasMany(e => e.DOCTOR)
                .WithRequired(e => e.OSMOTR1)
                .HasForeignKey(e => e.OSMOTR)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SOSTAV>()
                .Property(e => e.SOSTAV1)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SOSTAV>()
                .HasMany(e => e.GROUPS)
                .WithRequired(e => e.SOSTAV1)
                .HasForeignKey(e => e.SOSTAV)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SOSTAV>()
                .HasMany(e => e.OSMOTR)
                .WithRequired(e => e.SOSTAV1)
                .HasForeignKey(e => e.SOSTAV)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SOSTAV>()
                .HasMany(e => e.TRENEROVKA)
                .WithRequired(e => e.SOSTAV1)
                .HasForeignKey(e => e.SOSTAV)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TRENER>()
                .Property(e => e.TRENEROVKA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TRENEROVKA>()
                .Property(e => e.TRENEROVKA1)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TRENEROVKA>()
                .Property(e => e.SOSTAV)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TRENEROVKA>()
                .HasMany(e => e.TRENER)
                .WithRequired(e => e.TRENEROVKA1)
                .HasForeignKey(e => e.TRENEROVKA)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<USERS>()
                .HasMany(e => e.DOCTOR)
                .WithOptional(e => e.USERS)
                .HasForeignKey(e => e.USER_ID);

            modelBuilder.Entity<USERS>()
                .HasMany(e => e.SPORTSMENS)
                .WithOptional(e => e.USERS)
                .HasForeignKey(e => e.USER_ID);

            modelBuilder.Entity<USERS>()
                .HasMany(e => e.TRENER)
                .WithOptional(e => e.USERS)
                .HasForeignKey(e => e.USER_ID);
        }
    }
}
