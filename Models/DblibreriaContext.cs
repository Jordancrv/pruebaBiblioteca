using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace pruebaBiblioteca.Models;

public partial class DblibreriaContext : DbContext
{
    public DblibreriaContext()
    {
    }

    public DblibreriaContext(DbContextOptions<DblibreriaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Autor> Autors { get; set; }

    public virtual DbSet<Categorium> Categoria { get; set; }

    public virtual DbSet<Editorial> Editorials { get; set; }

    public virtual DbSet<Libro> Libros { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Autor>(entity =>
        {
            entity.HasKey(e => e.AutorId).HasName("PK__Autor__F58AE9293959921D");

            entity.ToTable("Autor");

            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        modelBuilder.Entity<Categorium>(entity =>
        {
            entity.HasKey(e => e.CategoriaId).HasName("PK__Categori__F353C1E50715FA02");

            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        modelBuilder.Entity<Editorial>(entity =>
        {
            entity.HasKey(e => e.EditorialId).HasName("PK__Editoria__D54C82EEB441B4E9");

            entity.ToTable("Editorial");

            entity.Property(e => e.Nombre).HasMaxLength(100);

            entity.HasOne(d => d.Libro).WithMany(p => p.Editorials)
                .HasForeignKey(d => d.LibroId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Editorial__Libro__5441852A");
        });

        modelBuilder.Entity<Libro>(entity =>
        {
            entity.HasKey(e => e.LibroId).HasName("PK__Libro__35A1ECEDDA935816");

            entity.ToTable("Libro");

            entity.Property(e => e.Titulo).HasMaxLength(200);

            entity.HasOne(d => d.Autor).WithMany(p => p.Libros)
                .HasForeignKey(d => d.AutorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Libro__AutorId__4BAC3F29");

            entity.HasMany(d => d.Categoria).WithMany(p => p.Libros)
                .UsingEntity<Dictionary<string, object>>(
                    "LibroCategorium",
                    r => r.HasOne<Categorium>().WithMany()
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__LibroCate__Categ__5165187F"),
                    l => l.HasOne<Libro>().WithMany()
                        .HasForeignKey("LibroId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__LibroCate__Libro__5070F446"),
                    j =>
                    {
                        j.HasKey("LibroId", "CategoriaId").HasName("PK__LibroCat__7A94D0F39DC48462");
                        j.ToTable("LibroCategoria");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
