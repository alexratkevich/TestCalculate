using UnityEngine;
using Zenject;
using Presenter;
using UniRx;
using TMPro;

namespace Views
{
    public class CalcInputFieldView : MonoBehaviour
    {
        private TMP_InputField _resultText;
        [Inject]
        private ICalcPresenter _calcPresenter;

        void Start()
        {
            _resultText = GetComponent<TMP_InputField>();
            _resultText.onDeselect.AddListener((x) => { _calcPresenter.SaveInputField(x); }); ;

            var reactive_property = _calcPresenter.OutputData;
            reactive_property.Subscribe((x) =>
            {
                ShowResult(x);
            }).AddTo(this);
        }

        private void ShowResult(string result)
        {
            _resultText.text = result;
        }

        private void OnApplicationQuit()
        {
            _calcPresenter.SaveInputField(_resultText.text);
        }

        private void OnApplicationFocus(bool hasFocus)
        {
            if (!hasFocus)
                _calcPresenter.SaveInputField(_resultText.text);
        }
    }
}