using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLibrary.Models;

public partial class MypersonaldbContext : DbContext
{
    public MypersonaldbContext()
    {
    }

    public MypersonaldbContext(DbContextOptions<MypersonaldbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DeutschAdjSuffix> DeutschAdjSuffixes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=ERWIN\\SQLEXPRESS;Database=mypersonaldb;User ID=erwin031823;Password=valor1826;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DeutschAdjSuffix>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.ToTable("deutsch_adj_suffix");

            entity.Property(e => e.Oid)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("oid");
            entity.Property(e => e.Gender)
                .HasMaxLength(50)
                .HasColumnName("gender");
            entity.Property(e => e.GermanCase)
                .HasMaxLength(50)
                .HasColumnName("german_case");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .HasColumnName("type");
            entity.Property(e => e.Value)
                .HasMaxLength(50)
                .HasColumnName("value");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
