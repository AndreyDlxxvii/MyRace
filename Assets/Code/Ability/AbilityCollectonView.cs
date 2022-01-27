using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace MyRaces
{
    public class AbilityCollectonView : MonoBehaviour, IAbilityView, IDisposable
    {
        [SerializeField] private Button _bombButton;
        [SerializeField] private Button _shildButton;
        [SerializeField] private Button _showHideButton;

        //private Animator _animator;
        private RectTransform _rectTransformBombButton;
        private RectTransform _rectTransformShildButton;
        private RectTransform _rectTransforShowHideButton;
        // private readonly int _showAnim = Animator.StringToHash("AbilityShow");
        // private readonly int _hideAnim = Animator.StringToHash("AbilityHide");
        
        public event Action<AbilityType> UseRequest;
        public event Action ShowHide;

        private IReadOnlyList<IItem> _abilityItems;

        private void Start()
        {
            _rectTransformBombButton = _bombButton.GetComponent<RectTransform>();
            _rectTransformShildButton = _shildButton.GetComponent<RectTransform>();
            _rectTransforShowHideButton = _showHideButton.GetComponent<RectTransform>();
            //_animator = GetComponent<Animator>();
            _showHideButton.onClick.AddListener(() => ShowHide());
            _bombButton.onClick.AddListener(()=> OnUseRequested(AbilityType.Bomb));
            _shildButton.onClick.AddListener(() => OnUseRequested(AbilityType.Shild));
        }

        private void OnUseRequested(AbilityType type)
        
        {
            UseRequest?.Invoke(type);
        }
        
        public void Show()
        {
            _rectTransformBombButton.DOMoveX(20, 2f);
            _rectTransformShildButton.DOMoveX(20, 2f);
            _rectTransforShowHideButton.DORotate(new Vector3(0f,0f,180f), 2f);
            // _animator.SetInteger(_showAnim, 1);
            // _animator.SetInteger(_hideAnim, 0);
        }

        public void Hide()
        {
            _rectTransformBombButton.DOMoveX(-20, 2f);
            _rectTransformShildButton.DOMoveX(-20, 2f);
            _rectTransforShowHideButton.DORotate(new Vector3(0f,0f,0f), 2f);
            // _animator.SetInteger(_hideAnim, 1);
            // _animator.SetInteger(_showAnim, 0);
        }

        public void Dispose()
        {
            _showHideButton.onClick.RemoveAllListeners();
            _bombButton.onClick.RemoveAllListeners();
            _shildButton.onClick.RemoveAllListeners();
        }
    }
}