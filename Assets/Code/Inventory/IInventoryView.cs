using System;
using System.Collections.Generic;

namespace MyRaces
{
    public interface IInventoryView
    {
        public event Action <int> WeightBtn;
        public event Action <int> WindowBtn;
        public event Action <int> SuspensionButton;
        public event Action <int> TireButton;
        void Display(IReadOnlyList<IItem> items);
    }
}