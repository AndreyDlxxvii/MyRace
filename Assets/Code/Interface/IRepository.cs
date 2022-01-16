using System.Collections.Generic;

namespace MyRaces
{
    public interface IRepository<TKey, TValue>
    {
        IReadOnlyDictionary<TKey, TValue> Collection { get; }
    }
}