using System;
using System.Collections.Generic;
using UnityEngine;

namespace MyRaces
{
    public class AbilityRepository : BaseController, IRepository<int, IAbility>
    {
        public IReadOnlyDictionary<int, IAbility> Collection => _abilityMapByld;
        private Dictionary<int, IAbility> _abilityMapByld = new Dictionary<int, IAbility>();

        public AbilityRepository(List<AbilityItemConfig> configs)
        {
            PopulateItems(configs);
        }

        private void PopulateItems(List<AbilityItemConfig> configs)
        {
            foreach (var config in configs)
            {
                if (_abilityMapByld.ContainsKey(config.Id))
                    continue;
                _abilityMapByld.Add(config.Id, CreateAbility(config));
            }
        }

        protected override void OnDispose()
        {
            _abilityMapByld.Clear();
        }
        private IAbility CreateAbility(AbilityItemConfig config)
        {
            switch (config.AbilityType)
            {
                case AbilityType.Bomb:
                    return new AbilityBomb(config);
                
                case AbilityType.Shild:
                    return new AbilityShild(config);
                
                default:
                    Debug.LogError("Not type");
                    return null;
            }
        }
    }
}