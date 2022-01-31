using JoostenProductions;
using UnityEngine;
using UnityEngine.UI;

namespace MyRaces
{
    internal class BtnControlView : BaseInputView
    {
        [SerializeField] private Button _leftButton;
        [SerializeField] private Button _rightButton;
        [SerializeField] private Button _exitButton;

        public override void Init(SubscribeProperty <float> leftMove, SubscribeProperty<float> rightMove, float speed)
        {
            base.Init(leftMove, rightMove, speed);
            UpdateManager.SubscribeToUpdate(() => Move(speed));
        }

        public void Move(float speed)
        {
            _leftButton.onClick.AddListener(() => OnLeftMove(speed));
            _rightButton.onClick.AddListener(() => OnRightMove(speed));
            _exitButton.onClick.AddListener(Exit);
        }
        private void Exit()
        {
            Application.Quit();
        }
        
        private void OnDestroy()
        {
            _leftButton.onClick.RemoveAllListeners();
            _rightButton.onClick.RemoveAllListeners();
            _exitButton.onClick.RemoveAllListeners();
            UpdateManager.UnsubscribeFromUpdate(() => Move(1));
        }
    }
}