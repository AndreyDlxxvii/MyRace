using UnityEngine;

namespace MyRaces
{
    internal abstract class BaseInputView : MonoBehaviour
    {
        private SubscribeProperty<float> _leftMove;
        private SubscribeProperty<float> _rightMove;
        protected float _speed;
        
        
        public virtual void Init(SubscribeProperty<float> leftMove, SubscribeProperty<float> rightMove, float speed)
        {
            _leftMove = leftMove;
            _rightMove = rightMove;
            _speed = speed;
        }

        protected virtual void OnLeftMove(float value)
        {
            _leftMove.value = value;
        }

        protected virtual void OnRightMove(float value)
        {
            _rightMove.value = value;
        }
    }
}