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
        private readonly IItemsRepository _repositoryInfo;
        private readonly Transform _placeUI;

        public InventoryController(List<ItemConfig> itemConfigs, Transform placeUI)
        {
            _placeUI = placeUI;
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
            if (objectView.TryGetComponent(out InventoryView inventoryView ))
            {
                return inventoryView;
            }
            else return null;
        }
        public void ShowInventory(int Id)
        {
            var q = _repositoryInfo.Items[Id];
            var equippedItem = _inventoryModel.GetEquippedItems();
            if (!equippedItem.Contains(q))
            {
                _inventoryModel.EquipItem(q);
            }
            else
            {
                _inventoryModel.UnEquipItem(q);
            }
            _inventoryView.Display(equippedItem);
        }
    }
}