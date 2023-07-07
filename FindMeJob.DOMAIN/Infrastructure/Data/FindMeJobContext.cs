using System;
using System.Collections.Generic;
using FindMeJob.DOMAIN.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace FindMeJob.DOMAIN.Infrastructure.Data;

public partial class FindMeJobContext : DbContext
{
    public FindMeJobContext()
    {
    }

    public FindMeJobContext(DbContextOptions<FindMeJobContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Empresa> Empresa { get; set; }

    public virtual DbSet<OfertaTrabajo> OfertaTrabajo { get; set; }

    public virtual DbSet<PerfilProfesional> PerfilProfesional { get; set; }

    public virtual DbSet<Postulacion> Postulacion { get; set; }

    public virtual DbSet<Usuario> Usuario { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-MK2FPDD2;Database=FindMeJob;Integrated Security=true;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Empresa>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Empresa__3213E83FE3AC805D");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Contrasena)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("contrasena");
            entity.Property(e => e.CorreoElectronico)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("correoElectronico");
            entity.Property(e => e.Direccion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.Logo)
                .HasMaxLength(500)
                .HasColumnName("logo");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Ruc)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ruc");
            entity.Property(e => e.Telefono)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<OfertaTrabajo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OfertaTr__3213E83F74A2A743");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("descripcion");
            entity.Property(e => e.EmpresaId).HasColumnName("empresa_id");
            entity.Property(e => e.FechaCaducidad)
                .HasColumnType("date")
                .HasColumnName("fecha_caducidad");
            entity.Property(e => e.FechaPublicacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_publicacion");
            entity.Property(e => e.Titulo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("titulo");

            entity.HasOne(d => d.Empresa).WithMany(p => p.OfertaTrabajo)
                .HasForeignKey(d => d.EmpresaId)
                .HasConstraintName("FK__OfertaTra__empre__182C9B23");
        });

        modelBuilder.Entity<PerfilProfesional>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PerfilPr__3213E83FF4563B2D");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");

            entity.HasOne(d => d.Usuario).WithMany(p => p.PerfilProfesional)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK__PerfilPro__usuar__1920BF5C");
        });

        modelBuilder.Entity<Postulacion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Postulac__3213E83F20C9B7B8");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FechaPostulacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_postulacion");
            entity.Property(e => e.OfertaId).HasColumnName("oferta_id");
            entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");

            entity.HasOne(d => d.Oferta).WithMany(p => p.Postulacion)
                .HasForeignKey(d => d.OfertaId)
                .HasConstraintName("FK__Postulaci__ofert__1A14E395");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Postulacion)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK__Postulaci__usuar__1B0907CE");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuario__3213E83FB7BF845D");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Contrasena)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("contrasena");
            entity.Property(e => e.CorreoElectronico)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("correoElectronico");
            entity.Property(e => e.Direccion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.Dni)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("dni");
            entity.Property(e => e.NombreCompleto)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombreCompleto");
            entity.Property(e => e.Telefono)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("telefono");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
