using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MyRaces
{
    public class AbilityCollectonView : MonoBehaviour, IAbilityView, IDisposable
    {
        [SerializeField] private Button _bombButton;
        [SerializeField] private Button _shildButton;
        [SerializeField] private Button _showHideButton;
        private Animator _animator;

        private readonly int _showAnim = Animator.StringToHash("AbilityShow");
        private readonly int _hideAnim = Animator.StringToHash("AbilityHide");
        
        public event Action<AbilityType> UseRequest;
        public event Action ShowHide;

        private IReadOnlyList<IItem> _abilityItems;

        private void Start()
        {
            _animator = GetComponent<Animator>();
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
            _animator.SetInteger(_showAnim, 1);
            _animator.SetInteger(_hideAnim, 0);
        }

        public void Hide()
        {
            _animator.SetInteger(_hideAnim, 1);
            _animator.SetInteger(_showAnim, 0);
        }

        public void Dispose()
        {
            _showHideButton.onClick.RemoveAllListeners();
            _bombButton.onClick.RemoveAllListeners();
            _shildButton.onClick.RemoveAllListeners();
        }
    }
}