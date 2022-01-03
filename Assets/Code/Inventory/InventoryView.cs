using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace MyRaces
{
    public class InventoryView : MonoBehaviour, IInventoryView
    {
        [SerializeField] private Button _weightButton;
        [SerializeField] private Button _windowButton;
        [SerializeField] private Button _suspensionButton;
        [SerializeField] private Button _tireButton;

        private Transform _carTransform;
        private CarView _carView;
        public event Action <int> WeightBtn;
        public event Action <int> WindowBtn;
        public event Action <int> SuspensionButton;
        public event Action <int> TireButton;

        private void Start()
        {
            _weightButton.onClick.AddListener(() => WeightBtn(1));
            _windowButton.onClick.AddListener(() => WindowBtn(2));
            _suspensionButton.onClick.AddListener(() => SuspensionButton(3));
            _tireButton.onClick.AddListener(() => TireButton(4));
            _carTransform = FindObjectOfType<CarView>().transform;
            
            //здесь не совсем знаю как правильно было, протащить CarView или же получить через GetComponent
            _carView = _carTransform.GetComponent<CarView>();
        }

        public void Display(IReadOnlyList<IItem> items)
        {
            foreach (Transform child in _carTransform)
            {
                child.GetComponentInChildren<SpriteRenderer>().sprite = null;
            }
            foreach (var item in items)
            {
                switch (item.Id)
                {
                   case 1:
                       _carView.WeightTransform.GetComponent<SpriteRenderer>().sprite = item.Sprite;
                       break;
                   case 2:
                       _carView.WindowTransform.GetComponent<SpriteRenderer>().sprite = item.Sprite;
                       break;
                   case 3:
                       _carView.SpringLeftTransform.GetComponent<SpriteRenderer>().sprite = item.Sprite;
                       _carView.SpringRightTransform.GetComponent<SpriteRenderer>().sprite = item.Sprite;
                       break;
                   case 4:
                       _carView.TireLeftTransform.GetComponent<SpriteRenderer>().sprite = item.Sprite;
                       _carView.TireRightTransform.GetComponent<SpriteRenderer>().sprite = item.Sprite;
                       break;
                }
            }
        }
    }
}