using UnityEngine;

namespace MyRaces
{
    public interface IItem
    {
        int Id { get; set; }
        ItemInfo Info { get; set; }
        
        public Sprite Sprite { get; set; }

        public TypeUpgradeItems TypeUpgrade { get; set; }
    }
}