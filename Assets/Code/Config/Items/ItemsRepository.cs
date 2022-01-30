using System.Collections.Generic;

namespace MyRaces
{
    public class ItemsRepository : BaseController, IRepository<int,IItem>
    {
        public IReadOnlyDictionary<int, IItem> Collection => _collectionMapById;
        
        private Dictionary<int, IItem> _collectionMapById = new Dictionary<int, IItem>();

        public ItemsRepository(List<ItemConfig> itemConfigs)
        {
            PopulateItems(itemConfigs);
        }

        protected override void OnDispose()
        {
            _collectionMapById.Clear();
        }

        private void PopulateItems(List<ItemConfig> itemConfigs)
        {
            foreach (var ellConfig in itemConfigs)
            {
                if (_collectionMapById.ContainsKey(ellConfig.ID))
                {
                    continue;
                }
                _collectionMapById.Add(ellConfig.ID, CreateItem(ellConfig));
            }
        }

        private IItem CreateItem(ItemConfig ellConfig)
        {
            return new Item
            {
                Id = ellConfig.ID, 
                Info = new ItemInfo {Title = ellConfig.Title},
                Sprite = ellConfig.Sprite,
                TypeUpgrade = ellConfig.TypeUpgradeItems
            };
        }
    }
}