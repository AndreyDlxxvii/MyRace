using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MyRaces
{
    public class InventoryController : BaseController, IInventoryController
    {
        private readonly ResourcesPath _viewPath = new ResourcesPath{PathResources = "Prefabs/ItemMenu"};
        private readonly IInventoryModel _inventoryModel;
        private readonly IInventoryView _inventoryView;
        private readonly IRepository<int, IItem> _repositoryInfo;
        private readonly Transform _placeUI;
        private readonly CarView _сarView;

        public InventoryController(List<ItemConfig> itemConfigs, Transform placeUI, CarView car)
        {
            _placeUI = placeUI;
            _сarView = car;
            _inventoryModel = new InventoryModel();
            _inventoryView = LoadView();
            _repositoryInfo = new ItemsRepository(itemConfigs);
            _inventoryView.WeightBtn += ShowInventory;
            _inventoryView.WindowBtn += ShowInventory;
            _inventoryView.SuspensionButton += ShowInventory;
            _inventoryView.TireButton += ShowInventory;

        }
        private InventoryView LoadView()
        {
            var objectView = Object.Instantiate(ResourceLoader.LoadPrefab(_viewPath), _placeUI, false);
            AddGameObject(objectView);

            if (objectView.TryGetComponent(out InventoryView inventoryView))
            {
                inventoryView.CarView = _сarView;
                return inventoryView; 
            }
                
            return null;
        }
        public void ShowInventory(int Id)
        {
            var item = _repositoryInfo.Collection[Id];
            var equippedItem = _inventoryModel.GetEquippedItems();
            if (!equippedItem.Contains(item))
            {
                _inventoryModel.EquipItem(item);
            }
            else
            {
                _inventoryModel.UnEquipItem(item);
            }
            _inventoryView.Display(equippedItem);
        }

        protected override void OnDispose()
        {
            _inventoryView.WeightBtn -= ShowInventory;
            _inventoryView.WindowBtn -= ShowInventory;
            _inventoryView.SuspensionButton -= ShowInventory;
            _inventoryView.TireButton -= ShowInventory;
        }
    }
}