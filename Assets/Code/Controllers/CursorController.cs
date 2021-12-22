using UnityEngine;

namespace MyRaces
{
    public class CursorController : BaseController
    {
        private readonly ResourcesPath _viewPath = new ResourcesPath {PathResources = "Prefabs/Cursor"};
        private CursorTrailView _trailView;

        public CursorController()
        {
            _trailView = LoadView();
        }
        
        private CursorTrailView LoadView()
        {
            var objectView = Object.Instantiate(ResourceLoader.LoadPrefab(_viewPath));
            AddGameObject(objectView);
            if (objectView.TryGetComponent(out CursorTrailView View ))
            {
                return View;
            }
            return null;
        }

        public void OnUpdate()
        {
            Vector3 temp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            temp.z = 0f;
            _trailView.transform.position = temp;
        }
    }
}