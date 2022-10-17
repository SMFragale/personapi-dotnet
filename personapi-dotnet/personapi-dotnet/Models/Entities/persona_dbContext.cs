using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace personapi_dotnet.Models.Entities
{
    public partial class persona_dbContext : DbContext
    {
        public persona_dbContext()
        {
        }

        public persona_dbContext(DbContextOptions<persona_dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Estudio> Estudios { get; set; } = null!;
        public virtual DbSet<Persona> Personas { get; set; } = null!;
        public virtual DbSet<Profesion> Profesions { get; set; } = null!;
        public virtual DbSet<Telefono> Telefonos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=persona_db;Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Estudio>(entity =>
            {
                entity.HasKey(e => new { e.IdProf, e.CcPer })
                    .HasName("PK__Estudios__FB3F71A60D66D208");

                entity.Property(e => e.IdProf).HasColumnName("id_prof");

                entity.Property(e => e.CcPer).HasColumnName("cc_per");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("fecha");

                entity.Property(e => e.Univer)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("univer");

                entity.HasOne(d => d.CcPerNavigation)
                    .WithMany(p => p.Estudios)
                    .HasForeignKey(d => d.CcPer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Estudios__cc_per__2B3F6F97");

                entity.HasOne(d => d.IdProfNavigation)
                    .WithMany(p => p.Estudios)
                    .HasForeignKey(d => d.IdProf)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Estudios__id_pro__2A4B4B5E");
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.HasKey(e => e.Cc)
                    .HasName("PK__Persona__3213666D7BB192F1");

                entity.ToTable("Persona");

                entity.Property(e => e.Cc)
                    .ValueGeneratedNever()
                    .HasColumnName("cc");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("apellido");

                entity.Property(e => e.Edad).HasColumnName("edad");

                entity.Property(e => e.Genero)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("genero")
                    .IsFixedLength();

                entity.Property(e => e.Nombre)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Profesion>(entity =>
            {
                entity.ToTable("Profesion");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Dest)
                    .HasColumnType("text")
                    .HasColumnName("dest");

                entity.Property(e => e.Nom)
                    .HasMaxLength(90)
                    .IsUnicode(false)
                    .HasColumnName("nom");
            });

            modelBuilder.Entity<Telefono>(entity =>
            {
                entity.HasKey(e => new { e.Num, e.Duenio })
                    .HasName("PK__Telefono__1EE0396B24860D5B");

                entity.ToTable("Telefono");

                entity.Property(e => e.Num)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("num");

                entity.Property(e => e.Duenio).HasColumnName("duenio");

                entity.Property(e => e.Oper)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("oper");

                entity.HasOne(d => d.DuenioNavigation)
                    .WithMany(p => p.Telefonos)
                    .HasForeignKey(d => d.Duenio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Telefono__duenio__2E1BDC42");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
