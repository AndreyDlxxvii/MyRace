using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class LocalizationView : MonoBehaviour
    {
        [SerializeField] private Button _buttonEn;
        [SerializeField] private Button _buttonRus;

        private void Start()
        {
            _buttonRus.onClick.AddListener(() => ChangeLocale(0));
            _buttonEn.onClick.AddListener(() => ChangeLocale(1));
        }

        private void ChangeLocale(int index)
        {
            LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[index];
        }

        private void OnDestroy()
        {
            _buttonRus.onClick.RemoveAllListeners();
            _buttonEn.onClick.RemoveAllListeners();
        }
    }
}