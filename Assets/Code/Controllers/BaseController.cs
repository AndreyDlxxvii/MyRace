using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace MyRaces
{
    public class BaseController : IDisposable
    {
        List<BaseController> _baseControllers = new List<BaseController>();
        List<GameObject> _gameObjects = new List<GameObject>();

        private bool _isDisposed;

        public void Dispose()
        {
            if (_isDisposed)
                return;
            _isDisposed = true;
            foreach (var baseController in _baseControllers)
            {
                baseController.Dispose();
            }

            _baseControllers.Clear();

            foreach (var myGameObject in _gameObjects)
            {
                Object.Destroy(myGameObject);
            }

            _gameObjects.Clear();

            OnDispose();
        }

        protected void AddControler(BaseController baseController)
        {
            _baseControllers.Add(baseController);
        }

        protected void AddGameObject(GameObject gameObject)
        {
            _gameObjects.Add(gameObject);
        }

        protected virtual void OnDispose()
        {
        }
    }
}
