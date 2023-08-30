using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TestMVC.Models.Data
{
    public partial class BlogDatabaseContext : DbContext
    {
        public BlogDatabaseContext()
        {
        }

        public BlogDatabaseContext(DbContextOptions<BlogDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Catergorium> Catergoria { get; set; } = null!;
        public virtual DbSet<File> Files { get; set; } = null!;
        public virtual DbSet<Licitacion> Licitacions { get; set; } = null!;
        public virtual DbSet<Post> Posts { get; set; } = null!;
        public virtual DbSet<ResponsableLicitacion> ResponsableLicitacions { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Catergorium>(entity =>
            {
                entity.ToTable("CATERGORIA");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<File>(entity =>
            {
                entity.ToTable("FILES");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FPath)
                    .IsUnicode(false)
                    .HasColumnName("F_PATH");

                entity.Property(e => e.Titulo)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("TITULO");
            });

            modelBuilder.Entity<Licitacion>(entity =>
            {
                entity.ToTable("LICITACION");

                entity.Property(e => e.IdCategoria).HasColumnName("Id_Categoria");

                entity.Property(e => e.IdResponsable).HasColumnName("Id_Responsable");

                entity.Property(e => e.Titulo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Licitacions)
                    .HasForeignKey(d => d.IdCategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LICITACION_CATERGORIA");

                entity.HasOne(d => d.IdResponsableNavigation)
                    .WithMany(p => p.Licitacions)
                    .HasForeignKey(d => d.IdResponsable)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LICITACION_RESPONSABLE_LICITACION");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.ToTable("Post");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Archivos).HasColumnName("ARCHIVOS");

                entity.Property(e => e.Autor)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("AUTOR");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPCION");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("FECHA");

                entity.Property(e => e.Titulo)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("TITULO");

                entity.HasOne(d => d.ArchivosNavigation)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.Archivos)
                    .HasConstraintName("FK_Post_FILES");
            });

            modelBuilder.Entity<ResponsableLicitacion>(entity =>
            {
                entity.ToTable("RESPONSABLE_LICITACION");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
