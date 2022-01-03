using System.Collections.Generic;

namespace MyRaces
{
    public interface IInventoryModel
    {
        IReadOnlyList<IItem> GetEquippedItems();
        void EquipItem(IItem item);
        void UnEquipItem(IItem item);
    }
}