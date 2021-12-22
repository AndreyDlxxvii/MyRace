using System;

namespace MyRaces
{
    public interface IReadOnlySubscribeProperty<T>
    {
        T value { get; }

        void SubcribeOnChange(Action<T> subscriptionAction);
        
        void UnSubcribeOnChange(Action<T> unSubscriptionAction);
    }
}