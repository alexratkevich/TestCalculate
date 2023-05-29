using UnityEngine;
using System.Collections;
using UseCases;
using System;
using Views;
using UnityEngine.Serialization;

namespace Presenter
{
	public class CalcPresenter : MonoBehaviour, ICalcPresenter
	{
        [FormerlySerializedAs("calcView")]
        [SerializeField]
        private CalcView _calcView;
        private ICalcUseCases _calcUseCases;       

        public void Initialize(ICalcUseCases calcUseCases)
        {
            _calcUseCases = calcUseCases;
            _calcView.Initialize(this);
            _calcUseCases.RestoreResult();
        }

        public void AddListenerOnCalculatedResult(Action<string> OnResultChanged)
        {
            _calcUseCases.OnResultChanged += (x => OnResultChanged?.Invoke(x));
        }

        public void CalcResult(string inputData)
        {
            if (!TryParseInputData(inputData, out int[] inputs))
            {
                _calcUseCases.SetError();
            }
            else
                _calcUseCases.CalcResult(inputs[0], inputs[1]);            
        }

        public string GetResult()
        {
            return _calcUseCases.GetResult();
        }

        private bool TryParseInputData(string inputData, out int[] inputs)
        {            
            inputs = new int[2];
            string[] splitInputs = inputData.Replace(" ", "").Split("+");

            if (splitInputs.Length != 2)
                return false;
            else
            {
                if (!int.TryParse(splitInputs[0], out int input1))
                    return false;
                if (!int.TryParse(splitInputs[1], out int input2))
                    return false;

                inputs[0] = input1;
                inputs[1] = input2;
            }

            return true;
        }

        public void SaveInputField(string inputField)
        {
            _calcUseCases.SaveInputField(inputField);
            _calcUseCases.SaveResult();
        }
    }

}