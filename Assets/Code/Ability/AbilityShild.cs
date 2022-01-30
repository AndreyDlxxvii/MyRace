using UnityEngine;

namespace MyRaces
{
    public class AbilityShild : IAbility
    {
        public AbilityItemConfig AbilityItemConfig => _abilityItemConfig;

        private readonly AbilityItemConfig _abilityItemConfig;
        public AbilityShild(AbilityItemConfig abilityItemConfig)
        {
            _abilityItemConfig = abilityItemConfig;
        }

        public void Apply()
        {
            var shild = Object.Instantiate(_abilityItemConfig.Rigidbody2D);
        }
    }
}