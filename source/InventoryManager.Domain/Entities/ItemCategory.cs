using InventoryManager.Domain.Entities.Common;

namespace InventoryManager.Domain.Entities;

public class ItemCategory : BaseEntity
{
    public Guid ItemId { get; private set; }
    public Item Item { get; private set; }
    
    public Guid CategoryId { get; private set; }
    public Category Category { get; private set; }
    
    private ItemCategory() {}
    public ItemCategory(Guid itemId, Guid categoryId)
    {
        ItemId = itemId;
        CategoryId = categoryId;
    }
}