using UnityEngine;
using UseCases;
using UniRx;

namespace Presenter
{
	public class CalcPresenter : MonoBehaviour, ICalcPresenter
	{
        public IReadOnlyReactiveProperty<string> OutputData => _outputData;
        private readonly ReactiveProperty<string> _outputData = new ReactiveProperty<string>();
        private ICalcUseCases _calcUseCases;

        public void Initialize(ICalcUseCases calcUseCases)
        {
            _calcUseCases = calcUseCases;
            
            _calcUseCases.OutputData.Subscribe((x) =>
            {
                _outputData.Value = x;
            }).AddTo(this);

            _calcUseCases.RestoreResult();            
        }

        public void CalcResult(string inputData)
        {
            if (!TryParseInputData(inputData, out int[] inputs))
                _calcUseCases.SetError();
            else
                _calcUseCases.CalcResult(inputs[0], inputs[1]);            
        }       

        public string GetInOutResult()
        {
            return _calcUseCases.GetInOutData();
        }

        public void SaveInputField(string inputField)
        {
            _calcUseCases.SaveInputField(inputField);
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
    }

}