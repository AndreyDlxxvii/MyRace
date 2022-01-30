using System;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
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

        private void Start()
        {
            _tireBackSprite.GetComponent<Transform>().DORotate(new Vector3(0, 0, -180), 1, RotateMode.FastBeyond360).SetLoops(-1).SetEase(Ease.Linear);
            _tireForwardSprite.GetComponent<Transform>().DORotate(new Vector3(0, 0, -180), 1, RotateMode.FastBeyond360).SetLoops(-1).SetEase(Ease.Linear);
        }

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
