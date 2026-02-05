using Microsoft.EntityFrameworkCore;

namespace pwa_api.Data;

public class ComputerInventoryItem
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string PictureUrl { get; set; } = string.Empty;
}

public class InventoryDbContext : DbContext
{
    public InventoryDbContext(DbContextOptions<InventoryDbContext> options) : base(options)
    {
    }

    public DbSet<ComputerInventoryItem> ComputerInventories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Seed 50 computer inventory items
        modelBuilder.Entity<ComputerInventoryItem>().HasData(
            new ComputerInventoryItem { Id = 1, Name = "Gaming Laptop Pro", Price = 1299.99m, PictureUrl = "https://picsum.photos/seed/gaminglaptop/400/400" },
            new ComputerInventoryItem { Id = 2, Name = "Ultrabook 15 inch", Price = 999.99m, PictureUrl = "https://picsum.photos/seed/ultrabook/400/400" },
            new ComputerInventoryItem { Id = 3, Name = "Desktop Tower i9", Price = 1899.99m, PictureUrl = "https://picsum.photos/seed/desktopi9/400/400" },
            new ComputerInventoryItem { Id = 4, Name = "Mini PC Compact", Price = 549.99m, PictureUrl = "https://picsum.photos/seed/minipc/400/400" },
            new ComputerInventoryItem { Id = 5, Name = "Workstation Pro", Price = 2499.99m, PictureUrl = "https://picsum.photos/seed/workstation/400/400" },
            new ComputerInventoryItem { Id = 6, Name = "Chromebook 14", Price = 349.99m, PictureUrl = "https://picsum.photos/seed/chromebook/400/400" },
            new ComputerInventoryItem { Id = 7, Name = "All-in-One PC 27", Price = 1199.99m, PictureUrl = "https://picsum.photos/seed/allinone/400/400" },
            new ComputerInventoryItem { Id = 8, Name = "Budget Laptop", Price = 449.99m, PictureUrl = "https://picsum.photos/seed/budgetlaptop/400/400" },
            new ComputerInventoryItem { Id = 9, Name = "Server Rack Unit", Price = 3999.99m, PictureUrl = "https://picsum.photos/seed/serverrack/400/400" },
            new ComputerInventoryItem { Id = 10, Name = "MacBook Alternative", Price = 1099.99m, PictureUrl = "https://picsum.photos/seed/macbookalt/400/400" },
            new ComputerInventoryItem { Id = 11, Name = "Ryzen Gaming PC", Price = 1599.99m, PictureUrl = "https://picsum.photos/seed/ryzengaming/400/400" },
            new ComputerInventoryItem { Id = 12, Name = "Business Laptop", Price = 799.99m, PictureUrl = "https://picsum.photos/seed/businesslaptop/400/400" },
            new ComputerInventoryItem { Id = 13, Name = "Thin Client PC", Price = 299.99m, PictureUrl = "https://picsum.photos/seed/thinclient/400/400" },
            new ComputerInventoryItem { Id = 14, Name = "Convertible 2-in-1", Price = 899.99m, PictureUrl = "https://picsum.photos/seed/convertible/400/400" },
            new ComputerInventoryItem { Id = 15, Name = "Intel NUC Kit", Price = 649.99m, PictureUrl = "https://picsum.photos/seed/intelnuc/400/400" },
            new ComputerInventoryItem { Id = 16, Name = "Custom Build RTX", Price = 2199.99m, PictureUrl = "https://picsum.photos/seed/customrtx/400/400" },
            new ComputerInventoryItem { Id = 17, Name = "Student Laptop", Price = 399.99m, PictureUrl = "https://picsum.photos/seed/studentlaptop/400/400" },
            new ComputerInventoryItem { Id = 18, Name = "Content Creator PC", Price = 1799.99m, PictureUrl = "https://picsum.photos/seed/creatorpc/400/400" },
            new ComputerInventoryItem { Id = 19, Name = "Refurbished Desktop", Price = 249.99m, PictureUrl = "https://picsum.photos/seed/refurbished/400/400" },
            new ComputerInventoryItem { Id = 20, Name = "High-End Workstation", Price = 4999.99m, PictureUrl = "https://picsum.photos/seed/highendws/400/400" },
            new ComputerInventoryItem { Id = 21, Name = "Compact Desktop", Price = 599.99m, PictureUrl = "https://picsum.photos/seed/compactdesktop/400/400" },
            new ComputerInventoryItem { Id = 22, Name = "Gaming Notebook", Price = 1449.99m, PictureUrl = "https://picsum.photos/seed/gamingnotebook/400/400" },
            new ComputerInventoryItem { Id = 23, Name = "Enterprise Server", Price = 5999.99m, PictureUrl = "https://picsum.photos/seed/enterpriseserver/400/400" },
            new ComputerInventoryItem { Id = 24, Name = "Barebone PC Kit", Price = 199.99m, PictureUrl = "https://picsum.photos/seed/barebone/400/400" },
            new ComputerInventoryItem { Id = 25, Name = "Touch Screen Laptop", Price = 1049.99m, PictureUrl = "https://picsum.photos/seed/touchlaptop/400/400" },
            new ComputerInventoryItem { Id = 26, Name = "AMD Threadripper PC", Price = 3499.99m, PictureUrl = "https://picsum.photos/seed/threadripper/400/400" },
            new ComputerInventoryItem { Id = 27, Name = "Ultra Thin Notebook", Price = 1149.99m, PictureUrl = "https://picsum.photos/seed/ultrathin/400/400" },
            new ComputerInventoryItem { Id = 28, Name = "Media Center PC", Price = 899.99m, PictureUrl = "https://picsum.photos/seed/mediacenter/400/400" },
            new ComputerInventoryItem { Id = 29, Name = "Development Workstation", Price = 2299.99m, PictureUrl = "https://picsum.photos/seed/devworkstation/400/400" },
            new ComputerInventoryItem { Id = 30, Name = "Portable Mini Laptop", Price = 499.99m, PictureUrl = "https://picsum.photos/seed/portablemini/400/400" },
            new ComputerInventoryItem { Id = 31, Name = "VR Ready Desktop", Price = 1699.99m, PictureUrl = "https://picsum.photos/seed/vrdesktop/400/400" },
            new ComputerInventoryItem { Id = 32, Name = "Fanless Silent PC", Price = 749.99m, PictureUrl = "https://picsum.photos/seed/fanlesspc/400/400" },
            new ComputerInventoryItem { Id = 33, Name = "Streaming PC Build", Price = 1399.99m, PictureUrl = "https://picsum.photos/seed/streamingpc/400/400" },
            new ComputerInventoryItem { Id = 34, Name = "Educational Laptop", Price = 329.99m, PictureUrl = "https://picsum.photos/seed/edulaptop/400/400" },
            new ComputerInventoryItem { Id = 35, Name = "CAD Workstation", Price = 2899.99m, PictureUrl = "https://picsum.photos/seed/cadworkstation/400/400" },
            new ComputerInventoryItem { Id = 36, Name = "Home Office PC", Price = 679.99m, PictureUrl = "https://picsum.photos/seed/homeofficepc/400/400" },
            new ComputerInventoryItem { Id = 37, Name = "Esports Gaming Rig", Price = 1999.99m, PictureUrl = "https://picsum.photos/seed/esportsrig/400/400" },
            new ComputerInventoryItem { Id = 38, Name = "Rugged Laptop", Price = 1599.99m, PictureUrl = "https://picsum.photos/seed/ruggedlaptop/400/400" },
            new ComputerInventoryItem { Id = 39, Name = "AI Training Server", Price = 7999.99m, PictureUrl = "https://picsum.photos/seed/aiserver/400/400" },
            new ComputerInventoryItem { Id = 40, Name = "Dual Screen Laptop", Price = 1899.99m, PictureUrl = "https://picsum.photos/seed/dualscreen/400/400" },
            new ComputerInventoryItem { Id = 41, Name = "SFF Gaming PC", Price = 1349.99m, PictureUrl = "https://picsum.photos/seed/sffgaming/400/400" },
            new ComputerInventoryItem { Id = 42, Name = "Water Cooled Desktop", Price = 2599.99m, PictureUrl = "https://picsum.photos/seed/watercooled/400/400" },
            new ComputerInventoryItem { Id = 43, Name = "Budget Gaming Laptop", Price = 849.99m, PictureUrl = "https://picsum.photos/seed/budgetgaming/400/400" },
            new ComputerInventoryItem { Id = 44, Name = "Professional Ultrabook", Price = 1399.99m, PictureUrl = "https://picsum.photos/seed/proultrab/400/400" },
            new ComputerInventoryItem { Id = 45, Name = "Entry Level Desktop", Price = 379.99m, PictureUrl = "https://picsum.photos/seed/entrylevel/400/400" },
            new ComputerInventoryItem { Id = 46, Name = "Music Production PC", Price = 1649.99m, PictureUrl = "https://picsum.photos/seed/musicpc/400/400" },
            new ComputerInventoryItem { Id = 47, Name = "4K Video Editing PC", Price = 2099.99m, PictureUrl = "https://picsum.photos/seed/4keditpc/400/400" },
            new ComputerInventoryItem { Id = 48, Name = "Lightweight Notebook", Price = 729.99m, PictureUrl = "https://picsum.photos/seed/lightweight/400/400" },
            new ComputerInventoryItem { Id = 49, Name = "Multi-GPU Workstation", Price = 5499.99m, PictureUrl = "https://picsum.photos/seed/multigpu/400/400" },
            new ComputerInventoryItem { Id = 50, Name = "Travel Business Laptop", Price = 1079.99m, PictureUrl = "https://picsum.photos/seed/travellaptop/400/400" }
        );
    }
}
