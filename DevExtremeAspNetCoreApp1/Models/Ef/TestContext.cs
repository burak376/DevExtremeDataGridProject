using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DevExtremeAspNetCoreApp1.Models.Ef;

public partial class TestContext : DbContext
{
    public TestContext()
    {
    }

    public TestContext(DbContextOptions<TestContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Sti> Stis { get; set; }

    public virtual DbSet<Stk> Stks { get; set; }

    public virtual DbSet<DataList> DataLists { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Initial Catalog=Test;uid=sa;pwd=burak1990;Trusted_Connection = True;Integrated Security=True;MultipleActiveResultSets=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Sti>(entity =>
        {
            entity.HasKey(e => new { e.EvrakNo, e.Tarih, e.IslemTur }).HasName("pkSTI");

            entity.ToTable("STI");

            entity.Property(e => e.EvrakNo)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.Birim)
                .IsRequired()
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.Fiyat).HasColumnType("numeric(25, 6)");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.MalKodu)
                .IsRequired()
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Miktar).HasColumnType("numeric(25, 6)");
            entity.Property(e => e.Tutar).HasColumnType("numeric(25, 6)");
        });

        modelBuilder.Entity<Stk>(entity =>
        {
            entity.HasKey(e => e.MalKodu).HasName("pkSTK");

            entity.ToTable("STK");

            entity.Property(e => e.MalKodu)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.MalAdi)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
