using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace JADSVC.Data.DataDB;

public partial class JadsvcsContext : DbContext
{
    public JadsvcsContext()
    {
    }

    public JadsvcsContext(DbContextOptions<JadsvcsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Feature> Features { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<ServiceLevel> ServiceLevels { get; set; }

    public virtual DbSet<ServiceOrder> ServiceOrders { get; set; }

    public virtual DbSet<ServiceOrderFeature> ServiceOrderFeatures { get; set; }

    public virtual DbSet<StateChange> StateChanges { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserFeature> UserFeatures { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-SE1QL0U;Initial Catalog=JADSVCS;Integrated Security=True;;TrustServerCertificate = true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Feature>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Features__3214EC2744CE296F");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Icon)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.IsAlaCarteOnly).HasColumnName("IsALaCarteOnly");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ServiceId).HasColumnName("ServiceID");
            entity.Property(e => e.ServiceLevelId).HasColumnName("ServiceLevelID");

            entity.HasOne(d => d.Service).WithMany(p => p.Features)
                .HasForeignKey(d => d.ServiceId)
                .HasConstraintName("FK__Features__Servic__2C3393D0");

            entity.HasOne(d => d.ServiceLevel).WithMany(p => p.Features)
                .HasForeignKey(d => d.ServiceLevelId)
                .HasConstraintName("FK__Features__Servic__2D27B809");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Service__3214EC27869F2FAB");

            entity.ToTable("Service");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ServiceLevel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ServiceL__3214EC27F65F73AB");

            entity.ToTable("ServiceLevel");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ServiceId).HasColumnName("ServiceID");

            entity.HasOne(d => d.Service).WithMany(p => p.ServiceLevels)
                .HasForeignKey(d => d.ServiceId)
                .HasConstraintName("FK__ServiceLe__Servi__46E78A0C");
        });

        modelBuilder.Entity<ServiceOrder>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Transact__3214EC2721A02DD7");

            entity.ToTable("ServiceOrder");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Amount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.FeaturesAlc)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("FeaturesALC");
            entity.Property(e => e.FeeAmount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ServiceId).HasColumnName("ServiceID");
            entity.Property(e => e.ServiceLevelId).HasColumnName("ServiceLevelID");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TxnId).HasColumnName("TxnID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Service).WithMany(p => p.ServiceOrders)
                .HasForeignKey(d => d.ServiceId)
                .HasConstraintName("FK__Transacti__Servi__38996AB5");

            entity.HasOne(d => d.ServiceLevel).WithMany(p => p.ServiceOrders)
                .HasForeignKey(d => d.ServiceLevelId)
                .HasConstraintName("FK__Transacti__FromS__36B12243");

            entity.HasOne(d => d.User).WithMany(p => p.ServiceOrders)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Transacti__UserI__35BCFE0A");
        });

        modelBuilder.Entity<ServiceOrderFeature>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.FeatureId).HasColumnName("FeatureID");
            entity.Property(e => e.ServiceOrderId).HasColumnName("ServiceOrderID");

            entity.HasOne(d => d.Feature).WithMany(p => p.ServiceOrderFeatures)
                .HasForeignKey(d => d.FeatureId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ServiceOrderFeatures_Features");

            entity.HasOne(d => d.ServiceOrder).WithMany(p => p.ServiceOrderFeatures)
                .HasForeignKey(d => d.ServiceOrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ServiceOrderFeatures_ServiceOrder");
        });

        modelBuilder.Entity<StateChange>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__StateCha__3214EC27FD424D4F");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ActionDate).HasColumnType("datetime");
            entity.Property(e => e.ActionDescription)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ActionType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserId).HasColumnName("UserID");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__User__3214EC27FC8F6B99");

            entity.ToTable("User");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CurrentServiceLevelId).HasColumnName("CurrentServiceLevelID");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ServiceId).HasColumnName("ServiceID");

            entity.HasOne(d => d.Service).WithMany(p => p.Users)
                .HasForeignKey(d => d.ServiceId)
                .HasConstraintName("FK__User__ServiceID__4CA06362");
        });

        modelBuilder.Entity<UserFeature>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UserFeat__3214EC270CBE3647");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.FeatureId).HasColumnName("FeatureID");
            entity.Property(e => e.ServiceId).HasColumnName("ServiceID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Feature).WithMany(p => p.UserFeatures)
                .HasForeignKey(d => d.FeatureId)
                .HasConstraintName("FK__UserFeatu__Featu__30F848ED");

            entity.HasOne(d => d.Service).WithMany(p => p.UserFeatures)
                .HasForeignKey(d => d.ServiceId)
                .HasConstraintName("FK__UserFeatu__Servi__4E88ABD4");

            entity.HasOne(d => d.User).WithMany(p => p.UserFeatures)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__UserFeatu__UserI__4F7CD00D");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
