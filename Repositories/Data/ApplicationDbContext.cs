using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Repositories.Entities;

namespace Repositories.Data;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Gamelevel> Gamelevels { get; set; }

    public virtual DbSet<Gameprogress> Gameprogresses { get; set; }

    public virtual DbSet<Inventory> Inventories { get; set; }

    public virtual DbSet<Resultlevel> Resultlevels { get; set; }

    public virtual DbSet<Spawn> Spawns { get; set; }

    public virtual DbSet<Spawnpoint> Spawnpoints { get; set; }

    public virtual DbSet<Wave> Waves { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=towerdf;Username=postgres;Password=12345");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("customer_pkey");

            entity.ToTable("customer");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .HasColumnName("password");
            entity.Property(e => e.Point).HasColumnName("point");
            entity.Property(e => e.Username)
                .HasMaxLength(100)
                .HasColumnName("username");
        });

        modelBuilder.Entity<Gamelevel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("gamelevel_pkey");

            entity.ToTable("gamelevel");

            entity.HasIndex(e => e.Level, "gamelevel_level_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Coin).HasColumnName("coin");
            entity.Property(e => e.Heart).HasColumnName("heart");
            entity.Property(e => e.Level).HasColumnName("level");
        });

        modelBuilder.Entity<Gameprogress>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("gameprogress_pkey");

            entity.ToTable("gameprogress");

            entity.HasIndex(e => e.CustomerId, "gameprogress_customer_id_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Currentcoin).HasColumnName("currentcoin");
            entity.Property(e => e.Currentheart).HasColumnName("currentheart");
            entity.Property(e => e.Currentpoint).HasColumnName("currentpoint");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.WaveId).HasColumnName("wave_id");

            entity.HasOne(d => d.Customer).WithOne(p => p.Gameprogress)
                .HasForeignKey<Gameprogress>(d => d.CustomerId)
                .HasConstraintName("fk_progress_customer");

            entity.HasOne(d => d.Wave).WithMany(p => p.Gameprogresses)
                .HasForeignKey(d => d.WaveId)
                .HasConstraintName("fk_progress_wave");
        });

        modelBuilder.Entity<Inventory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("inventory_pkey");

            entity.ToTable("inventory");

            entity.HasIndex(e => e.CustomerId, "inventory_customer_id_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Attackspeed).HasColumnName("attackspeed");
            entity.Property(e => e.Boomskill).HasColumnName("boomskill");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.Damage).HasColumnName("damage");
            entity.Property(e => e.Range).HasColumnName("range");
            entity.Property(e => e.Thunderskill).HasColumnName("thunderskill");
            entity.Property(e => e.Upgradepoint).HasColumnName("upgradepoint");

            entity.HasOne(d => d.Customer).WithOne(p => p.Inventory)
                .HasForeignKey<Inventory>(d => d.CustomerId)
                .HasConstraintName("fk_inventory_customer");
        });

        modelBuilder.Entity<Resultlevel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("resultlevel_pkey");

            entity.ToTable("resultlevel");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.GameLevelId).HasColumnName("game_level_id");
            entity.Property(e => e.Star).HasColumnName("star");

            entity.HasOne(d => d.Customer).WithMany(p => p.Resultlevels)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("fk_result_customer");

            entity.HasOne(d => d.GameLevel).WithMany(p => p.Resultlevels)
                .HasForeignKey(d => d.GameLevelId)
                .HasConstraintName("fk_result_gamelevel");
        });

        modelBuilder.Entity<Spawn>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("spawn_pkey");

            entity.ToTable("spawn");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Enemynumber).HasColumnName("enemynumber");
            entity.Property(e => e.Enemytype)
                .HasMaxLength(100)
                .HasColumnName("enemytype");
            entity.Property(e => e.Priority).HasColumnName("priority");
            entity.Property(e => e.SpawnpointId).HasColumnName("spawnpoint_id");

            entity.HasOne(d => d.Spawnpoint).WithMany(p => p.Spawns)
                .HasForeignKey(d => d.SpawnpointId)
                .HasConstraintName("fk_spawn_spawnpoint");
        });

        modelBuilder.Entity<Spawnpoint>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("spawnpoint_pkey");

            entity.ToTable("spawnpoint");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Delayatfirsttime).HasColumnName("delayatfirsttime");
            entity.Property(e => e.Delayeachspawn).HasColumnName("delayeachspawn");
            entity.Property(e => e.WaveId).HasColumnName("wave_id");

            entity.HasOne(d => d.Wave).WithMany(p => p.Spawnpoints)
                .HasForeignKey(d => d.WaveId)
                .HasConstraintName("fk_spawnpoint_wave");
        });

        modelBuilder.Entity<Wave>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("wave_pkey");

            entity.ToTable("wave");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Gamelevelid).HasColumnName("gamelevelid");
            entity.Property(e => e.Totalenemy).HasColumnName("totalenemy");
            entity.Property(e => e.Wavelevel).HasColumnName("wavelevel");

            entity.HasOne(d => d.Gamelevel).WithMany(p => p.Waves)
                .HasForeignKey(d => d.Gamelevelid)
                .HasConstraintName("fk_wave_gamelevel");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
