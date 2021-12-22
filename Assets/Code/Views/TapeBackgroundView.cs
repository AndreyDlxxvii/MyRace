using UnityEngine;

namespace MyRaces
{
    public class TapeBackgroundView : MonoBehaviour
    {
        [SerializeField] private BackGround[] _backgrounds;

        private IReadOnlySubscribeProperty <float> _diff;

        public void Init(IReadOnlySubscribeProperty<float> diff)
        {
            _diff = diff;
            _diff.SubcribeOnChange(Move);
        }

        protected void OnDestroy()
        {
            _diff?.SubcribeOnChange(Move);
        }

        private void Move(float value)
        {
            foreach (var background in _backgrounds)
                background.Move(-value);
        }
    }
}