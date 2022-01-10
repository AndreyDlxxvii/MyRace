using UnityEngine;

namespace MyRaces
{
    [CreateAssetMenu(fileName = "Item", menuName = "Item", order = 0)]
    public class ItemConfig : ScriptableObject
    {
        [SerializeField] private int _id;
        [SerializeField] private string _title;
        [SerializeField] private Sprite _sprite;

        public int ID => _id;

        public string Title => _title;

        public Sprite Sprite => _sprite;
    }
}