using UnityEngine;

namespace MyRaces
{
    public class BtnCtrlController : BaseController
    {
        private readonly ResourcesPath _viewPath = new ResourcesPath{PathResources = "Prefabs/BtnControll"};
        private readonly Transform _placeUI;
        private readonly BtnControlView _btnControlView;

        public BtnCtrlController(SubscribeProperty <float> leftMove, SubscribeProperty<float> rightMove, CarModel car, Transform placeUI)
        {
            _placeUI = placeUI;
            _btnControlView = LoadView();
            _btnControlView.Init(leftMove, rightMove, car.Speed);
        }
        
        private BtnControlView LoadView()
        {
            var objectView = Object.Instantiate(ResourceLoader.LoadPrefab(_viewPath), _placeUI, false);
            AddGameObject(objectView);
            if (objectView.TryGetComponent(out BtnControlView mainMenuView ))
            {
                return mainMenuView;
            }
            else return null;
        }
    }
}