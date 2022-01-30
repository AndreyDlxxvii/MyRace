using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace MyRaces
{
    public class AbilityController : BaseController, IAbilityController
    {
        private readonly ResourcesPath _viewPath = new ResourcesPath{PathResources = "Prefabs/AbilityMenu"};
        private Transform _placeUI;
        private IAbilityView _abilityView;
        private bool _flag = true;
        private AbilityRepository _abilityRepository;

        public AbilityController(Transform placeUI, List<AbilityItemConfig> abilityItemConfigs)
        {
            _placeUI = placeUI;
            _abilityView = LoadView();
            _abilityRepository = new AbilityRepository(abilityItemConfigs);
            _abilityView.ShowHide += ShowAbilityes;
            _abilityView.UseRequest += UseAbility;
        }

        private void UseAbility(AbilityType abilityType)
        {
            foreach (var ell in _abilityRepository.Collection)
            {
                if (ell.Value.AbilityItemConfig.AbilityType == abilityType)
                {
                    var ability = _abilityRepository.Collection[ell.Key];
                    ability.Apply();
                }
            }
        }


        private IAbilityView LoadView()
        {
            var objectView = Object.Instantiate(ResourceLoader.LoadPrefab(_viewPath), _placeUI, false);
            AddGameObject(objectView);

            if (objectView.TryGetComponent(out IAbilityView abilityView))
            {
                return abilityView; 
            }
                
            return null;
        }

        public void ShowAbilityes()
        {
            if (_flag)
            {
                _abilityView.Show();
                _flag = false;
            }
            else
            {
                _abilityView.Hide();
                _flag = true;
            }
        }

        protected override void OnDispose()
        {
            _abilityView.ShowHide -= ShowAbilityes;
            _abilityView.UseRequest -= UseAbility;
        }
    }
}