using InventoryManager.Domain.Entities.Common;

namespace InventoryManager.Domain.Entities;

public class Item : BaseEntity
{
    public Guid InventoryId { get; private set; }
    
    public string Name { get; private set; }
    public string Description { get; private set; } = "";
    public int Quantity { get; private set; }
    
    private readonly List<ItemCategory> _categories = new();
    public IReadOnlyCollection<ItemCategory> Categories => _categories.AsReadOnly();
    
    private Item() {}
    public Item(string name, string description, int quantity)
    {
        Name = name;
        Description = description;
        Quantity = quantity;
    }

    public void AddCategory(Guid categoryId)
    {
        if (_categories.Any(c => c.CategoryId == categoryId))
            return;
        
        _categories.Add(new ItemCategory(Id, categoryId));
    }
}