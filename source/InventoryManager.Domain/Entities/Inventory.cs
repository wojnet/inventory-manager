using InventoryManager.Domain.Entities.Common;

namespace InventoryManager.Domain.Entities;

public class Inventory : BaseEntity
{
    public string Name { get; private set; }
    public string Description { get; private set; } = "";
    public List<Item> Items { get; private set; } = new();

    private Inventory() {}
    public Inventory(string name, string description)
    {
        Name = name;
        Description = description;
    }
}