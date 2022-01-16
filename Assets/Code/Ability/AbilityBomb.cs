using UnityEngine;

namespace MyRaces
{
    public class AbilityBomb : IAbility
    {
        public AbilityItemConfig AbilityItemConfig => _abilityItemConfig;

        private readonly AbilityItemConfig _abilityItemConfig;
        public AbilityBomb(AbilityItemConfig abilityItemConfig)
        {
            _abilityItemConfig = abilityItemConfig;
        }

        public void Apply()
        {
            var bomb = Object.Instantiate(_abilityItemConfig.Rigidbody2D);
            bomb.AddForce(Vector2.right * _abilityItemConfig.Value, ForceMode2D.Impulse);
        }
    }
}