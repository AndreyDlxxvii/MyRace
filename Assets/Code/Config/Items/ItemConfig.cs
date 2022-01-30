using UnityEngine;

namespace MyRaces
{
    [CreateAssetMenu(fileName = "Item", menuName = "Item", order = 0)]
    public class ItemConfig : ScriptableObject
    {
        [SerializeField] private int _id;
        [SerializeField] private string _title;
        [SerializeField] private Sprite _sprite;
        [SerializeField] private TypeUpgradeItems _typeUpgradeItems;

        public TypeUpgradeItems TypeUpgradeItems => _typeUpgradeItems;

        public int ID => _id;

        public string Title => _title;

        public Sprite Sprite => _sprite;
    }
}