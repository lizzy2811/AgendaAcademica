using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AgendaAcademicaApi.Models;

public partial class AgendaAcademicaContext : DbContext
{
    public AgendaAcademicaContext()
    {
    }

    public AgendaAcademicaContext(DbContextOptions<AgendaAcademicaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Actividad> Actividads { get; set; }

    public virtual DbSet<Clase> Clases { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=Lizzy\\SQLEXPRESS;Database=AgendaAcademica;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Actividad>(entity =>
        {
            entity.HasKey(e => e.IdActividad).HasName("PK__Activida__5EAF86A4FB9D0DF8");

            entity.ToTable("Actividad");

            entity.Property(e => e.Calificacion).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .HasDefaultValue("Pendiente");
            entity.Property(e => e.NombreActividad).HasMaxLength(150);
            entity.Property(e => e.PuntosMaximos)
                .HasDefaultValue(100m)
                .HasColumnType("decimal(5, 2)");
            entity.Property(e => e.TipoActividad).HasMaxLength(50);

            entity.HasOne(d => d.IdClaseNavigation).WithMany(p => p.Actividads)
                .HasForeignKey(d => d.IdClase)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Actividad__IdCla__68487DD7");
        });

        modelBuilder.Entity<Clase>(entity =>
        {
            entity.HasKey(e => e.IdClase).HasName("PK__Clase__003FCC6F5BEB8205");

            entity.ToTable("Clase");

            entity.Property(e => e.NombreClase).HasMaxLength(100);
            entity.Property(e => e.Seccion).HasMaxLength(100);

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Clases)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Clase__IdUsuario__6383C8BA");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__5B65BF97C9DD55AF");

            entity.ToTable("Usuario");

            entity.HasIndex(e => e.Correo, "UQ__Usuario__60695A1901B95852").IsUnique();

            entity.Property(e => e.Contrasena).HasMaxLength(255);
            entity.Property(e => e.Correo).HasMaxLength(100);
            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
