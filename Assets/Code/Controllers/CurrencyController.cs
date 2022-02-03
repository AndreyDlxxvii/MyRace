using UnityEngine;

namespace MyRaces
{
    public class CurrencyController : BaseController
    {
        public CurrencyController(Transform placeForUI, CurrencyView currencyView)
        {
            var initCurencyView = Object.Instantiate(currencyView, placeForUI);
            AddGameObject(initCurencyView.gameObject);
            initCurencyView.RevreshView();
        }
    }
}