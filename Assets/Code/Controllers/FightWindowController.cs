using System;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Events;
using UnityEngine.Localization.Settings;
using Object = UnityEngine.Object;

namespace MyRaces
{
    public class FightWindowController : BaseController
    {
        private FightWindowView _fightWindowView;
        private ProfilePlayer _profilePlayer;
        
        private int _allCountMoneyPlayer;
        private int _allCountHealthPlayer;
        private int _allCountPowerPlayer;

        private Money _money;
        private Power _power;
        private Health _health;

        private Enemy _enemy;
        private int _enemyPower;
        
        public FightWindowController(Transform placeForUI, ProfilePlayer profilePlayer, FightWindowView fightView)
        {
            _profilePlayer = profilePlayer;
            _fightWindowView = Object.Instantiate(fightView, placeForUI);
            AddGameObject(_fightWindowView.gameObject);
        }

        public void RefreshView()
        {
            _enemy = new Enemy("Evil Bird");
            _money = new Money();
            _money.Attach(_enemy);
            _power = new Power();
            _power.Attach(_enemy);
            _health = new Health();
            _health.Attach(_enemy);
                
            _fightWindowView.AddMoneyButton.onClick.AddListener(() => ChangeMoney(true));
            _fightWindowView.MinusMoneyButton.onClick.AddListener(() => ChangeMoney(false));
            
            _fightWindowView.AddHealthButton.onClick.AddListener(() => ChangeHealth(true));
            _fightWindowView.MinusHealthButton.onClick.AddListener(() => ChangeHealth(false));
            
            _fightWindowView.AddPowerButton.onClick.AddListener(() => ChangePower(true));
            _fightWindowView.MinusPowerButton.onClick.AddListener(() => ChangePower(false));
            
            _fightWindowView.DropdownLanguage.onValueChanged.AddListener(delegate
            {
                ChangeLanguage( _fightWindowView.DropdownLanguage.value);
            });
            
            _fightWindowView.FightButton.onClick.AddListener(Fight);
            _fightWindowView.LeaveFightButton.onClick.AddListener(CloseWindow);
        }

        private void ChangeLanguage(int index)
        {
            LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[index];
        }

        private void CloseWindow()
        {
            _profilePlayer.CurrentState.value = GameState.Game;
        }

        private void ChangePower(bool isAddCount)
        {
            if (isAddCount && _allCountPowerPlayer < 100)
                _allCountPowerPlayer++;
            else if(_allCountPowerPlayer > 0 && _allCountPowerPlayer != 100)
                _allCountPowerPlayer--;
            ChangeDataWindow(_allCountPowerPlayer, DataType.Power);
        }
        

        private void ChangeHealth(bool isAddCount)
        {
            if (isAddCount && _allCountHealthPlayer < 100)
                _allCountHealthPlayer++;
            else if (_allCountHealthPlayer > 0 && _allCountHealthPlayer != 100)
                _allCountHealthPlayer--;
            ChangeDataWindow(_allCountHealthPlayer, DataType.Health);
        }

        private void ChangeMoney(bool isAddCount)
        {
            if (isAddCount && _allCountMoneyPlayer < 100)
                _allCountMoneyPlayer++;
            else if (_allCountMoneyPlayer > 0 && _allCountMoneyPlayer != 100)
                _allCountMoneyPlayer--;
                
            ChangeDataWindow(_allCountMoneyPlayer, DataType.Money);
        }
        
        private void Fight()
        {
            Debug.Log(_allCountPowerPlayer >= _enemyPower ? "Win" : "Lose");
        }
        private void ChangeDataWindow(int countChangeData, DataType dataType)
        {
            switch (dataType)
            {
                case DataType.Money:
                    _fightWindowView.CountMoneyText.text = $"{countChangeData}";
                    _money.CountMoney = countChangeData;
                    break;
                case DataType.Health:
                    _fightWindowView.CountHealthText.text = $"{countChangeData}";
                    _health.CountHealth = countChangeData;
                    break;
                case DataType.Power:
                    _fightWindowView.CountPowerText.text = $"{countChangeData}";
                    _power.CountPower = countChangeData;
                    break;
            }

            _enemyPower = _enemy.PowerEnemy;
            _fightWindowView.CountPowerEnemyText.text = $"{_enemyPower}";
        }

        protected override void OnDispose()
        {
            
            _fightWindowView.AddMoneyButton.onClick.RemoveAllListeners();
            _fightWindowView.MinusMoneyButton.onClick.RemoveAllListeners();
            _fightWindowView.AddHealthButton.onClick.RemoveAllListeners();
            _fightWindowView.MinusHealthButton.onClick.RemoveAllListeners();
            _fightWindowView.AddPowerButton.onClick.RemoveAllListeners();
            _fightWindowView.MinusPowerButton.onClick.RemoveAllListeners();
            _fightWindowView.FightButton.onClick.RemoveAllListeners();
            _fightWindowView.LeaveFightButton.onClick.RemoveAllListeners();
            _fightWindowView.DropdownLanguage.onValueChanged.RemoveAllListeners();
            
            _money.Detach(_enemy);
            _power.Detach(_enemy);
            _health.Detach(_enemy);
            base.OnDispose();
        }

    }
}