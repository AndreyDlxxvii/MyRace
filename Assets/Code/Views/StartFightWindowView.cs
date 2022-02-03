using UnityEngine;
using UnityEngine.UI;

namespace MyRaces
{
    public class StartFightWindowView : MonoBehaviour
    {
        [SerializeField] private Button _startFigth;

        public Button StartFigth => _startFigth;
    }
}