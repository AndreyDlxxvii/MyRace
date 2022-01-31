using System;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace MyRaces
{
    public class InventoryView : MonoBehaviour, IInventoryView, IDisposable
    {
        //TODO отработать проблемы ниже
        // 3) В InventoryView. WindowBtn(2);, SuspensionButton(3); -все это выглядит костыльно. 
        // Со стороны не понятно, что обозначают цифры 1, 2, 3... Судя по тому, что в 
        // Display по id меняются картинки на машинке, то лучше для каждого предмета сделать тип места прицепления к машинке 
        // (какой-нибудьenum PlaceAttachmentType) => тогда в Display можно будет проверять по этому enum. 
        // А также можно было бы заменить все эти делегаты:
        
        
        [SerializeField] private Button _weightButton;
        [SerializeField] private Button _windowButton;
        [SerializeField] private Button _suspensionButton;
        [SerializeField] private Button _tireButton;

        private RectTransform _weightButtonRectTransform;
        private RectTransform _windowButtonRectTransform;
        private RectTransform _suspensionButtonRectTransform;
        private RectTransform _tireButtonRectTransform;
        private float _duration = 1f;
        public event Action <int> WeightBtn;
        public event Action <int> WindowBtn;
        public event Action <int> SuspensionButton;
        public event Action <int> TireButton;

        public CarView CarView { get; set; }

        private void Awake()
        {
            _weightButtonRectTransform = _weightButton.GetComponent<RectTransform>();
            _windowButtonRectTransform = _windowButton.GetComponent<RectTransform>();
            _suspensionButtonRectTransform = _suspensionButton.GetComponent<RectTransform>();
            _tireButtonRectTransform = _tireButton.GetComponent<RectTransform>();
        }

        private void Start()
        {
            _weightButton.onClick.AddListener(call: () => { 
                WeightBtn?.Invoke(1);
                ChangeScaleRectTransform(_weightButtonRectTransform);
                });
            _windowButton.onClick.AddListener(() =>
            {
                WindowBtn?.Invoke(2);
                ChangeScaleRectTransform(_windowButtonRectTransform);
            });
            _suspensionButton.onClick.AddListener(() =>
            {
                SuspensionButton?.Invoke(3);
                ChangeScaleRectTransform(_suspensionButtonRectTransform);
            });
            _tireButton.onClick.AddListener(() =>
            {
                TireButton?.Invoke(4);
                ChangeScaleRectTransform(_tireButtonRectTransform);
            });
        }

        private void ChangeScaleRectTransform(RectTransform buttonRectTransform)
        {
            buttonRectTransform.DOScale(new Vector3(2f, 2f, 2f), _duration).onComplete += delegate
            {
                buttonRectTransform.DOScale(new Vector3(1f, 1f, 1f), _duration); };
        }
        

        public void Display(IReadOnlyList<IItem> items)
        {
            foreach (var child in CarView.AllSpriteRenderer)
            {
                child.sprite = null;
            }
            foreach (var item in items)
            {
                switch (item.TypeUpgrade)
                {
                   case TypeUpgradeItems.Weight:
                       CarView.WeightSprite.sprite = item.Sprite;
                       break;
                   case TypeUpgradeItems.Window:
                       CarView.WindowSprite.sprite = item.Sprite;
                       break;
                   case TypeUpgradeItems.Suspension:
                       CarView.SpringBackSprite.sprite = item.Sprite;
                       CarView.SpringForwardSprite.sprite = item.Sprite;
                       break;
                   case TypeUpgradeItems.Tire:
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