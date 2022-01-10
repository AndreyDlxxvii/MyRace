using UnityEngine;

namespace MyRaces.Config
{
    [CreateAssetMenu(fileName = "Item", menuName = "Item", order = 0)]
    public class ItemConfig : ScriptableObject
    {
        public int Id;
        public string Title;
    }
}