using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Repositories.DataObjects;

public partial class WardrobeWizard : DbContext
{
    public WardrobeWizard()
    {
    }

    public WardrobeWizard(DbContextOptions<WardrobeWizard> options)
        : base(options)
    {
    }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<Measurement> Measurements { get; set; }

    public virtual DbSet<Outfit> Outfits { get; set; }

    public virtual DbSet<User> Users { get; set; }

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(e => e.ItemId).HasName("PK__Items__52020FDD0043A348");

            entity.Property(e => e.ItemId).HasColumnName("item_id");
            entity.Property(e => e.Brand)
                .HasMaxLength(50)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("brand");
            entity.Property(e => e.Category)
                .HasMaxLength(50)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("category");
            entity.Property(e => e.Color)
                .HasMaxLength(50)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("color");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(255)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("image_url");
            entity.Property(e => e.Size)
                .HasMaxLength(10)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("size");
            entity.Property(e => e.Style)
                .HasMaxLength(50)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("style");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Items)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Item_User");
        });

        modelBuilder.Entity<Measurement>(entity =>
        {
            entity.HasKey(e => e.MeasurementsId).HasName("PK__measurem__EA6932D3F844418D");

            entity.ToTable("measurements");

            entity.Property(e => e.MeasurementsId).HasColumnName("measurements_id");
            entity.Property(e => e.Bust)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("bust");
            entity.Property(e => e.Height)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("height");
            entity.Property(e => e.Hip)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("hip");
            entity.Property(e => e.Size)
                .HasMaxLength(10)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("size");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.Waist)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("waist");
            entity.Property(e => e.Weight)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("weight");

            entity.HasOne(d => d.User).WithMany(p => p.Measurements)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_user_measurements");
        });

        modelBuilder.Entity<Outfit>(entity =>
        {
            entity.HasKey(e => e.OutfitId).HasName("PK__Outfits__8C13C99113509BD9");

            entity.Property(e => e.OutfitId).HasColumnName("outfit_id");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("name");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Outfits)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Outfit_User");

            entity.HasMany(d => d.Items).WithMany(p => p.Outfits)
                .UsingEntity<Dictionary<string, object>>(
                    "OutfitItem",
                    r => r.HasOne<Item>().WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_OutfitItems_Item"),
                    l => l.HasOne<Outfit>().WithMany()
                        .HasForeignKey("OutfitId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_OutfitItems_Outfit"),
                    j =>
                    {
                        j.HasKey("OutfitId", "ItemId").HasName("PK__OutfitIt__4933E96CB5538D0A");
                        j.ToTable("OutfitItems");
                        j.IndexerProperty<int>("OutfitId").HasColumnName("outfit_id");
                        j.IndexerProperty<int>("ItemId").HasColumnName("item_id");
                    });
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__users__B9BE370FEB91760A");

            entity.ToTable("users");

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("email");
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("gender");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("password");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("phone");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
