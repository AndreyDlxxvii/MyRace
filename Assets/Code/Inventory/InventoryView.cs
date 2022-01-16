using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace MyRaces
{
    public class InventoryView : MonoBehaviour, IInventoryView, IDisposable
    {
        [SerializeField] private Button _weightButton;
        [SerializeField] private Button _windowButton;
        [SerializeField] private Button _suspensionButton;
        [SerializeField] private Button _tireButton;

        public event Action <int> WeightBtn;
        public event Action <int> WindowBtn;
        public event Action <int> SuspensionButton;
        public event Action <int> TireButton;

        public CarView CarView { get; set; }

        private void Start()
        {
            _weightButton.onClick.AddListener(() => WeightBtn(1));
            _windowButton.onClick.AddListener(() => WindowBtn(2));
            _suspensionButton.onClick.AddListener(() => SuspensionButton(3));
            _tireButton.onClick.AddListener(() => TireButton(4));
        }

        public void Display(IReadOnlyList<IItem> items)
        {
            foreach (var child in CarView.AllSpriteRenderer)
            {
                child.sprite = null;
            }
            foreach (var item in items)
            {
                switch (item.Id)
                {
                   case 1:
                       CarView.WeightSprite.sprite = item.Sprite;
                       break;
                   case 2:
                       CarView.WindowSprite.sprite = item.Sprite;
                       break;
                   case 3:
                       CarView.SpringBackSprite.sprite = item.Sprite;
                       CarView.SpringForwardSprite.sprite = item.Sprite;
                       break;
                   case 4:
                       CarView.TireBackSprite.sprite = item.Sprite;
                       CarView.TireForwardSprite.sprite = item.Sprite;
                       break;
                }
            }
        }

        public void Dispose()
        {
            _weightButton.onClick.RemoveAllListeners();
            _windowButton.onClick.RemoveAllListeners();
            _suspensionButton.onClick.RemoveAllListeners();
            _tireButton.onClick.RemoveAllListeners();
        }
    }
}