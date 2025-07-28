using InventoryManager.Domain.Entities;
using InventoryManager.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace InventoryManager.Infrastructure.Data;

public class InventoryManagerDbContext : DbContext
{
    public InventoryManagerDbContext(DbContextOptions<InventoryManagerDbContext> options) : base(options) { }
    
    public DbSet<Category> Categories { get; set; }
    public DbSet<Inventory> Inventories { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<ItemCategory> ItemCategories { get; set; }
    public DbSet<ItemChangelog> ItemChangelogs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("category");
            
            entity.HasKey(e => e.Id);
            
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(48);

            entity.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(512);
            
            entity.HasMany(i => i.Items)
                .WithOne(ic => ic.Category)
                .HasForeignKey(ic => ic.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
        });
        
        modelBuilder.Entity<Inventory>(entity =>
        {
            entity.ToTable("inventory");
            
            entity.Property(e => e.Name).IsRequired();
            entity.Property(e => e.Description).IsRequired();
            
            entity.HasMany(e => e.Items)
                .WithOne()
                .HasForeignKey(e => e.InventoryId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.ToTable("item");
            
            entity.HasKey(e => e.Id);
            
            entity.Property(e => e.Name).IsRequired();
            entity.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(512);
            
            entity.Property(e => e.Quantity).IsRequired();
            
            entity.HasMany(e => e.Categories)
                .WithOne(ic => ic.Item)
                .HasForeignKey(ic => ic.ItemId)
                .OnDelete(DeleteBehavior.Cascade);
                
        });

        modelBuilder.Entity<ItemCategory>(entity =>
        {
            entity.ToTable("item_category");

            entity.HasKey(e => e.Id);

            entity.HasOne(ic => ic.Item)
                .WithMany(i => i.Categories)
                .HasForeignKey(ic => ic.ItemId);
            
            entity.HasOne(ic => ic.Category)
                .WithMany(i => i.Items)
                .HasForeignKey(ic => ic.CategoryId);
        });

        modelBuilder.Entity<ItemChangelog>(entity =>
        {
            entity.ToTable("item_changelog");
            
            entity.HasKey(e => e.Id);

            entity.Property(e => e.ItemAdded).IsRequired();
            
            entity.Property(e => e.ChangeDescription)
                .IsRequired()
                .HasMaxLength(128);
            
            entity.Property(e => e.ChangedProperty)
                .IsRequired()
                .HasMaxLength(4);
            
            entity.Property(e => e.PropertyType)
                .IsRequired()
                .HasMaxLength(4);
            
            entity.Property(e => e.OldValue)
                .IsRequired()
                .HasMaxLength(512);
            
            entity.Property(e => e.NewValue)
                .IsRequired()
                .HasMaxLength(512);
            
            entity.HasOne<Item>()
                .WithMany()
                .HasForeignKey(e => e.ItemId)
                .OnDelete(DeleteBehavior.Cascade);
        });
    }
}