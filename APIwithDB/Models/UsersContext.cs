using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace APIwithDB.Models;

public partial class UsersContext : DbContext
{
    public UsersContext()
    {
    }

    public UsersContext(DbContextOptions<UsersContext> options)
        : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=tcp:apishkalau-sql-server.database.windows.net,1433;Initial Catalog=users;Persist Security Info=False;User ID=sqladmin;Password=Madiyar777.;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC07BE3E8CB0");

            entity.Property(e => e.Address).HasMaxLength(200);
            entity.Property(e => e.City).HasMaxLength(100);
            entity.Property(e => e.Country).HasMaxLength(100);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Gender).HasMaxLength(50);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Password).HasMaxLength(100);
            entity.Property(e => e.PhoneNumber).HasMaxLength(15);
            entity.Property(e => e.PostalCode).HasMaxLength(10);
            entity.Property(e => e.State).HasMaxLength(100);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            entity.Property(e => e.Username).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
