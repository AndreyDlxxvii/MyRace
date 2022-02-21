using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace MyRaces
{
    public class AbilityShild : IAbility, IDisposable
    {
        public AbilityItemConfig AbilityItemConfig => _abilityItemConfig;
        
        private List<AsyncOperationHandle<GameObject>> _objects = new List<AsyncOperationHandle<GameObject>>();

        private readonly AbilityItemConfig _abilityItemConfig;
        public AbilityShild(AbilityItemConfig abilityItemConfig)
        {
            _abilityItemConfig = abilityItemConfig;
        }

        public void Apply()
        {
            Addressables.InstantiateAsync("Shild").Completed += CreateShild;
            //var shild = Object.Instantiate(_abilityItemConfig.Rigidbody2D);
        }

        private void CreateShild(AsyncOperationHandle<GameObject> shild)
        {
            _objects.Add(shild);
        }
        
        public void Dispose()
        {
            foreach (var bomb in _objects)
            {
                Addressables.ReleaseInstance(bomb);
            }
            _objects.Clear();
        }
    }
}