using UnityEngine;

namespace MyRaces
{
    [CreateAssetMenu(fileName = "AbilityItemConfig", menuName = "AbilityItemConfig", order = 0)]
    public class AbilityItemConfig : ScriptableObject
    {
        [SerializeField] private ItemConfig _itemConfig;
        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private AbilityType _abilityType;
        [SerializeField] private float _value;

        public ItemConfig ItemConfig => _itemConfig;

        public Rigidbody2D Rigidbody2D => _rigidbody2D;

        public AbilityType AbilityType => _abilityType;

        public float Value => _value;

        public int Id => _itemConfig.ID;
    }
}