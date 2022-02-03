using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Networking;
using Debug = UnityEngine.Debug;

namespace DefaultNamespace
{
    public class AssetBundleView : MonoBehaviour
    {
        private const string UrlImageAssetBundleLZ4 =
            "https://drive.google.com/uc?export=download&id=1RaC6ZRih-UOqOR5TVT_lkc5tQ5-yz_2x";
        private const string UrlImageAssetBundleLZMA =
            "https://drive.google.com/uc?export=download&id=1FM67NhwKQfs9AchFzehc1IWbA5qJMrdi";

        [SerializeField] private DataImageBundle [] _dataImageBundles;
        
        private AssetBundle _imageAssetBundle;
        private Stopwatch _stopwatch = new Stopwatch();
        protected IEnumerator DownloadSetAssetBundle()
        {
            _stopwatch.Start();
            
            yield return GetSpriteAssetBunble();

            if (_imageAssetBundle == null)
            {
                Debug.LogError("Failed");
                yield break;
            }

            SetDownloadAssets();
            yield return null;
            
            _stopwatch.Stop();
            Debug.Log(_stopwatch.ElapsedMilliseconds);
        }
        
        private IEnumerator GetSpriteAssetBunble()
        {
            var request = UnityWebRequestAssetBundle.GetAssetBundle(UrlImageAssetBundleLZ4);
            yield return request.SendWebRequest();
            while (!request.isDone)
                yield return null;

            StateReques(request, ref  _imageAssetBundle);
        }

        private void StateReques(UnityWebRequest request, ref AssetBundle imageAssetBundle)
        {
            if (request.error == null)
            {
                imageAssetBundle = DownloadHandlerAssetBundle.GetContent(request);
                Debug.Log("Complete");
            }
            else
            {
                Debug.LogError(request.error);
            }
        }
        
        private void SetDownloadAssets()
        {
            foreach (var dataImage in _dataImageBundles)
                dataImage.Image.sprite = _imageAssetBundle.LoadAsset<Sprite>(dataImage.NameAssetBundle);
            
        }
    }
}