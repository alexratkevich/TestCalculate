using UnityEngine;
using UnityEngine.UI;
using Zenject;
using Presenter;

namespace Views
{
    public class CalcButtonView : MonoBehaviour
    {
        private Button _calcButton;
        [Inject]
        private ICalcPresenter _calcPresenter;

        void Start()
        {
            _calcButton = GetComponent<Button>();

            _calcButton.onClick.AddListener(() =>
            {
                var inputData = _calcPresenter.GetInOutResult();
                _calcPresenter.CalcResult(inputData);
            });

        }
    }
}