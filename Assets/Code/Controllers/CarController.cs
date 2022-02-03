using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace MyRaces
{
    public class CarController : BaseController
    {
        private readonly ResourcesPath _viewPath = new ResourcesPath{PathResources = "Prefabs/Car"};
        private CarView _carView;

        public CarController()
        {
            _carView = LoadView();
        }
        
        private CarView LoadView()
        {
            var objectView = Object.Instantiate(ResourceLoader.LoadPrefab(_viewPath));
            AddGameObject(objectView);
            if (objectView.TryGetComponent(out CarView carView ))
            {
                return carView;
            }
            return null;
        }

        public CarView GetViewObject()
        {
            return _carView;
        }
    }
}
