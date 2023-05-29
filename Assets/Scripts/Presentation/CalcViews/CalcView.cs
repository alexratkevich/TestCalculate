using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Presenter;
using UseCases;
using UnityEngine.Serialization;
using TMPro;

namespace Views
{
	public class CalcView : MonoBehaviour
	{		
        [FormerlySerializedAs("calcButton")]
        [SerializeField]
        private Button _calcButton;
        [FormerlySerializedAs("resultText")]
        [SerializeField]
        private TMP_InputField _resultText;        

        private ICalcPresenter _calcPresenter;

        // Use this for initialization
        public void Initialize(ICalcPresenter calcPresenter)
		{
			_calcPresenter = calcPresenter;

			_calcButton.onClick.AddListener(() => { calcPresenter.CalcResult(_resultText.text); });
			calcPresenter.AddListenerOnCalculatedResult(ShowText);

            //Debug.Log($"{this.GetType()}. Initialize(). End");
        }


		private void ShowText(string result)
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