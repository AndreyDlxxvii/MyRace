using UnityEngine;

namespace MyRaces
{
    [CreateAssetMenu(fileName = "UpgradeItemConfig", menuName = "UpgradeItemConfig", order = 0)]
    public class UpgradeItemConfig : ScriptableObject
    {
        [SerializeField] private ItemConfig _itemConfig;
        [SerializeField] private UpgrateType _upgrateType;
        [SerializeField] private float _valueUpgeate;

        public int Id => _itemConfig.ID;

        public UpgrateType UpgrateType => _upgrateType;

        public float ValueUpgeate => _valueUpgeate;
    }

    public enum UpgrateType
    {
        None = 0,
        Speed = 1,
        Control = 2
    }
}