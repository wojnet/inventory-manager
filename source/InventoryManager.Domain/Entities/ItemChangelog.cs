using InventoryManager.Domain.Entities.Common;
using InventoryManager.Domain.Enums;

namespace InventoryManager.Domain.Entities;

public class ItemChangelog : BaseEntity
{
    public Guid ItemId { get; private set; }

    public bool ItemAdded { get; private set; }
    public string ChangeDescription { get; private set; }
    public string PropertyName { get; private set; }
    public ItemPropertyValueType PropertyType { get; private set; }
    public string OldValue { get; private set; }
    public string NewValue { get; private set; }
    
    private ItemChangelog() { }
    public ItemChangelog(
        Guid itemId,
        bool itemAdded,
        string changeDescription,
        string propertyName,
        string oldValue,
        string newValue
    )
    {
        ItemId = itemId;
        ItemAdded = itemAdded;
        ChangeDescription = changeDescription;
        PropertyName = propertyName;
        OldValue = oldValue;
        NewValue = newValue;
    }
}