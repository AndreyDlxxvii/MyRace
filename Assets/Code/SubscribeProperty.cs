using System;

namespace MyRaces
{
    public class SubscribeProperty<T> : IReadOnlySubscribeProperty<T>
    {
        private T _value;
        private Action<T> _onChangeValue;

        public T value
        {
            get => _value;
            set
            {
                _value = value;
                _onChangeValue?.Invoke(_value);
            }
        }
        public void SubcribeOnChange(Action<T> subscriptionAction)
        {
            _onChangeValue += subscriptionAction;
        }

        public void UnSubcribeOnChange(Action<T> unSubscriptionAction)
        {
            _onChangeValue -= unSubscriptionAction;
        }
    }
}