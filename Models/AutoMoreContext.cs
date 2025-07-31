using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AutoMore.Api.Models;

public partial class AutoMoreContext : DbContext
{
    public AutoMoreContext()
    {
    }

    public AutoMoreContext(DbContextOptions<AutoMoreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Action> Actions { get; set; }

    public virtual DbSet<AppDefinition> AppDefinitions { get; set; }

    public virtual DbSet<ExecutionLog> ExecutionLogs { get; set; }

    public virtual DbSet<Trigger> Triggers { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Workflow> Workflows { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=AutoMore;Password=123456789;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Action>(entity =>
        {
            entity.HasKey(e => e.ActionId).HasName("PK__Actions__FFE3F4D9B46DEEAC");

            entity.Property(e => e.Type).HasMaxLength(50);

            entity.HasOne(d => d.Workflow).WithMany(p => p.Actions)
                .HasForeignKey(d => d.WorkflowId)
                .HasConstraintName("FK__Actions__Workflo__5629CD9C");
        });

        modelBuilder.Entity<AppDefinition>(entity =>
        {
            entity.HasKey(e => e.AppId).HasName("PK__AppDefin__8E2CF7F9FB9B2AC3");

            entity.Property(e => e.AuthMethod).HasMaxLength(50);
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Type).HasMaxLength(20);
        });

        modelBuilder.Entity<ExecutionLog>(entity =>
        {
            entity.HasKey(e => e.LogId).HasName("PK__Executio__5E54864864D80174");

            entity.Property(e => e.ErrorMessage).HasMaxLength(500);
            entity.Property(e => e.FinishedAt).HasColumnType("datetime");
            entity.Property(e => e.StartedAt).HasColumnType("datetime");
            entity.Property(e => e.Status).HasMaxLength(20);

            entity.HasOne(d => d.Workflow).WithMany(p => p.ExecutionLogs)
                .HasForeignKey(d => d.WorkflowId)
                .HasConstraintName("FK__Execution__Workf__59063A47");
        });

        modelBuilder.Entity<Trigger>(entity =>
        {
            entity.HasKey(e => e.TriggerId).HasName("PK__Triggers__11321F62F8BA6BAF");

            entity.Property(e => e.LastExecutedAt).HasColumnType("datetime");
            entity.Property(e => e.Type).HasMaxLength(50);

            entity.HasOne(d => d.Workflow).WithMany(p => p.Triggers)
                .HasForeignKey(d => d.WorkflowId)
                .HasConstraintName("FK__Triggers__Workfl__534D60F1");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CC4C87101E9C");

            entity.HasIndex(e => e.Email, "UQ__Users__A9D10534C5E5BF3E").IsUnique();

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.PasswordHash).HasMaxLength(256);
            entity.Property(e => e.Role).HasMaxLength(20);
        });

        modelBuilder.Entity<Workflow>(entity =>
        {
            entity.HasKey(e => e.WorkflowId).HasName("PK__Workflow__5704A66A79D26B2C");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.User).WithMany(p => p.Workflows)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Workflows__UserI__4D94879B");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
