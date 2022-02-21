using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace MyRaces
{
    public class AbilityBomb : IAbility, IDisposable
    {
        public AbilityItemConfig AbilityItemConfig => _abilityItemConfig;

        private List<AsyncOperationHandle<GameObject>> _objects = new List<AsyncOperationHandle<GameObject>>();

        private readonly AbilityItemConfig _abilityItemConfig;
        public AbilityBomb(AbilityItemConfig abilityItemConfig)
        {
            _abilityItemConfig = abilityItemConfig;
        }

        public void Apply()
        {
            Addressables.InstantiateAsync("CannonBomb", Vector3.zero, Quaternion.identity).Completed += CreateBomb;
            // var bomb = Object.Instantiate(_abilityItemConfig.Rigidbody2D);
            // bomb.AddForce(Vector2.right * _abilityItemConfig.Value, ForceMode2D.Impulse);
        }

        private void CreateBomb(AsyncOperationHandle<GameObject> bomb)
        {
            _objects.Add(bomb);
            bomb.Result.GetComponent<Rigidbody2D>().AddForce(Vector2.right * _abilityItemConfig.Value, ForceMode2D.Impulse);
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