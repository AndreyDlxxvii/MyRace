using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class LoadWindowView : AssetBundleView
    {
        [SerializeField] private Button _loadAssetButton;
        [SerializeField] private Button _loadAddressaable;
        [SerializeField] private AssetReference _loadPref;
        [SerializeField] private RectTransform _layoutGroup;
        
        private List<AsyncOperationHandle<GameObject>> _listAsync = new List<AsyncOperationHandle<GameObject>>();

        private void Start()
        {
            _loadAssetButton.onClick.AddListener(LoadAsset);
            _loadAddressaable.onClick.AddListener(LoadAddressable);
        }

        private void LoadAddressable()
        {
           var addresable = Addressables.InstantiateAsync(_loadPref, _layoutGroup);
           _listAsync.Add(addresable);
        }

        private void OnDestroy()
        {
            _loadAssetButton.onClick.RemoveAllListeners();
            _loadAddressaable.onClick.RemoveAllListeners();
            foreach (var prefab in _listAsync)
                Addressables.ReleaseInstance(prefab);
            _listAsync.Clear();
        }

        private void LoadAsset()
        {
            _loadAssetButton.interactable = false;
            StartCoroutine(DownloadSetAssetBundle());
            
        }
    }
}