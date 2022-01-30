using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MyRaces
{
    public class CarView : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _windowSprite;
        [SerializeField] private SpriteRenderer _weightSprite;
        [SerializeField] private SpriteRenderer _springBackSprite;
        [SerializeField] private SpriteRenderer _springForwardSprite;
        [SerializeField] private SpriteRenderer _tireBackSprite;
        [SerializeField] private SpriteRenderer _tireForwardSprite;
        
        private List<SpriteRenderer> _allSpriteRenderer;

        public SpriteRenderer WindowSprite => _windowSprite;

        public SpriteRenderer WeightSprite => _weightSprite;

        public SpriteRenderer SpringBackSprite => _springBackSprite;

        public SpriteRenderer SpringForwardSprite => _springForwardSprite;

        public SpriteRenderer TireBackSprite => _tireBackSprite;

        public SpriteRenderer TireForwardSprite => _tireForwardSprite;

        public List<SpriteRenderer> AllSpriteRenderer
        {
            get
            {
                _allSpriteRenderer = GetComponentsInChildren<SpriteRenderer>().ToList();
                _allSpriteRenderer.RemoveAt(0);
                return _allSpriteRenderer;
            }
        }
    }
}
