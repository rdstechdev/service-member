using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

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
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("data source=DESKTOP-DASMNO1;initial catalog=Member;persist security info=True;user id=sa;password=Password123;");
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
