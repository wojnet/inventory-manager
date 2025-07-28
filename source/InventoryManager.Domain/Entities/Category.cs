using InventoryManager.Domain.Entities.Common;

namespace InventoryManager.Domain.Entities;

public class Category : BaseEntity
{
    public string Name { get; private set; }
    public string Description { get; private set; } = "";
    
    private readonly List<ItemCategory> _items = new();
    public IReadOnlyList<ItemCategory> Items => _items.AsReadOnly();
    
    private Category() { }
    public Category(string name, string description)
    {
        Name = name;
        Description = description;
    }
}