using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace Member.Context
{
    public partial class MemberContext : DbContext
    {
        public MemberContext()
        {
        }

        public MemberContext(DbContextOptions<MemberContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Memberlist> Memberlists { get; set; } = null!;
        public virtual DbSet<Personallist> Personallists { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                                                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                                                    .AddJsonFile("appsettings.json")
                                                    .Build();
                string connectionString = configuration.GetConnectionString("DefaultConnection");

                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Memberlist>(entity =>
            {
                entity.ToTable("MEMBERLIST");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Entryby)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ENTRYBY");

                entity.Property(e => e.Entrydate)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRYDATE");

                entity.Property(e => e.Idpersonal).HasColumnName("IDPERSONAL");

                entity.Property(e => e.Totalpremium).HasColumnName("TOTALPREMIUM");

                entity.HasOne(d => d.IdpersonalNavigation)
                    .WithMany(p => p.Memberlists)
                    .HasForeignKey(d => d.Idpersonal)
                    .HasConstraintName("MEMBER_PERSON");
            });

            modelBuilder.Entity<Memberlist>().Navigation(e => e.IdpersonalNavigation).AutoInclude();

            modelBuilder.Entity<Personallist>(entity =>
            {
                entity.ToTable("PERSONALLIST");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Entryby)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ENTRYBY");

                entity.Property(e => e.Entrydate)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRYDATE");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.Property(e => e.Startdate)
                    .HasColumnType("datetime")
                    .HasColumnName("STARTDATE");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
