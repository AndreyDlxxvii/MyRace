using System.Collections.Generic;

namespace MyRaces
{
    public class ItemsRepository : BaseController, IItemsRepository
    {
        public IReadOnlyDictionary<int, IItem> Items => _itemsMapById;
        
        private Dictionary<int, IItem> _itemsMapById = new Dictionary<int, IItem>();

        public ItemsRepository(List<ItemConfig> itemConfigs)
        {
            PopulateItems(itemConfigs);
        }

        protected override void OnDispose()
        {
            _itemsMapById.Clear();
        }

        private void PopulateItems(List<ItemConfig> itemConfigs)
        {
            foreach (var ellConfig in itemConfigs)
            {
                if (_itemsMapById.ContainsKey(ellConfig.ID))
                {
                    continue;
                }
                _itemsMapById.Add(ellConfig.ID, CreateItem(ellConfig));
            }
        }

        private IItem CreateItem(ItemConfig ellConfig)
        {
            return new Item
            {
                Id = ellConfig.ID, 
                Info = new ItemInfo {Title = ellConfig.Title},
                Sprite = ellConfig.Sprite
            };
        }
    }
}