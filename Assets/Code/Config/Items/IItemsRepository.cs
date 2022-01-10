using System.Collections.Generic;

namespace MyRaces
{
    public interface IItemsRepository
    {
        IReadOnlyDictionary<int, IItem> Items { get; }
    }
}