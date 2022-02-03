using UnityEngine;

namespace MyRaces
{
    public class CurrencyController : BaseController
    {
        public CurrencyController(Transform placeForUI, CurrencyView currencyView)
        {
            var initCurrencyView = Object.Instantiate(currencyView, placeForUI);
            AddGameObject(initCurrencyView.gameObject);
            initCurrencyView.RefreshView();
        }
    }
}