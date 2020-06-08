namespace DashboardCovid.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CovidContext : DbContext
    {
        public CovidContext()
            : base("name=CovidContext")
        {
        }

        public virtual DbSet<Countries> Countries { get; set; }
        public virtual DbSet<Global> Global { get; set; }
        public virtual DbSet<Turkey> Turkey { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Countries>()
                .Property(e => e.Country)
                .IsUnicode(false);

            modelBuilder.Entity<Countries>()
                .Property(e => e.CountryCode)
                .IsUnicode(false);

            modelBuilder.Entity<Countries>()
                .Property(e => e.Slug)
                .IsUnicode(false);

            modelBuilder.Entity<Countries>()
                .Property(e => e.date)
                .IsUnicode(false);

            modelBuilder.Entity<Turkey>()
                .Property(e => e.CountryCode)
                .IsFixedLength();
        }
    }
}
