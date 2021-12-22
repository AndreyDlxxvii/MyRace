using UnityEngine;

namespace MyRaces
{
    public class TapeBackgroundController : BaseController
    {
        public TapeBackgroundController(IReadOnlySubscribeProperty <float> leftMove, 
            IReadOnlySubscribeProperty<float> rightMove)
        {
            _view = LoadView();
            _diff = new SubscribeProperty<float>();
        
            _leftMove = leftMove;
            _rightMove = rightMove;
        
            _view.Init(_diff);
        
            _leftMove.SubcribeOnChange(Move);
            _rightMove.SubcribeOnChange(Move);
        }
    
        private readonly ResourcesPath _viewPath = new ResourcesPath {PathResources = "Prefabs/background"};
        private TapeBackgroundView _view;
        private readonly SubscribeProperty<float> _diff;
        private readonly IReadOnlySubscribeProperty<float> _leftMove;
        private readonly IReadOnlySubscribeProperty<float> _rightMove;

        protected override void OnDispose()
        {
            _leftMove.SubcribeOnChange(Move);
            _rightMove.SubcribeOnChange(Move);
        
            base.OnDispose();
        }

        private TapeBackgroundView LoadView()
        {
            var objView = Object.Instantiate(ResourceLoader.LoadPrefab(_viewPath));
            AddGameObject(objView);
        
            return objView.GetComponent<TapeBackgroundView>();
        }

        private void Move(float value)
        {
            _diff.value = value;
        }
    }
}