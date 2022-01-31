using System;
using UnityEngine;

namespace MyRaces
{
    [Serializable]
    public class Reward
    {
        public RewardType RewardType;
        public Sprite IconCurrency;
        public int CountCurrency;
    }
}