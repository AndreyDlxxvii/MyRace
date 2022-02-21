using System;
using System.Net.NetworkInformation;
using TMPro;
using UnityEngine;

namespace MyRaces
{
    public class CurrencyView : MonoBehaviour
    {
        private const string WoodKey = nameof(WoodKey); 
        private const string DiamondKey = nameof(DiamondKey); 
        public static CurrencyView Instance { get; private set; }

        [SerializeField] private TMP_Text _currentCountWood;
        [SerializeField] private TMP_Text _currentCountDiamond;
        private void Awake()
        {
            Instance = this; 
        }

        public void AddWood(int value)
        {
            SaveNewCountIntPlayer(WoodKey, value);
            RefreshView();
        }
        
        public void AddDiamond(int value)
        {
            SaveNewCountIntPlayer(DiamondKey, value);
            RefreshView();
        }

        public void RefreshView()
        {
            _currentCountWood.text = PlayerPrefs.GetInt(WoodKey, 0).ToString();
            _currentCountDiamond.text = PlayerPrefs.GetInt(DiamondKey, 0).ToString();
        }

        private void SaveNewCountIntPlayer(string key, int value)
        {
            var currentCount = PlayerPrefs.GetInt(key, 0);
            var newCount = currentCount + value;
            PlayerPrefs.SetInt(key, newCount);
        }
    }
}