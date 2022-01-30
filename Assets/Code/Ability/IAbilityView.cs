using System;
using System.Collections.Generic;
using UnityEngine;

namespace MyRaces
{
    public interface IAbilityView : IView
    {
        event Action<AbilityType> UseRequest;
        event Action ShowHide;
    }
}