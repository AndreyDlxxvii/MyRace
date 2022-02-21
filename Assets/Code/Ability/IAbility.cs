using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace MyRaces
{
    public interface IAbility
    {
        public AbilityItemConfig AbilityItemConfig { get; }
        void Apply();
    }
}