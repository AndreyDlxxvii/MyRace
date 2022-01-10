using UnityEngine;

namespace MyRaces
{
    [CreateAssetMenu(fileName = "UpgradeItemConfigDataSource", menuName = "UpgradeItemConfigDataSource", order = 0)]
    public class UpgradeItemConfigDataSource : ScriptableObject
    {
        [SerializeField] private UpgradeItemConfig[] _upgradeItemConfigs;

        public UpgradeItemConfig[] UpgradeItemConfigs => _upgradeItemConfigs;
    }
}