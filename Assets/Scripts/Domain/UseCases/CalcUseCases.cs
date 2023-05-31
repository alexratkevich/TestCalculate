using UnityEngine;
using Gateway;
using UniRx;

namespace UseCases
{
    public class CalcUseCases : ICalcUseCases
    {        
        private const string INPUT_DATA_PREFS = "INPUT_DATA";

        public IReadOnlyReactiveProperty<string> OutputData => _outputData;
        private readonly ReactiveProperty<string> _outputData;        
        private readonly ICalcDB _calcDB;        

        public CalcUseCases(ICalcDB calcDB)
        {
            _calcDB = calcDB;
            _outputData = new ReactiveProperty<string>();
        }        

        public void CalcResult(int a, int b)
        {
            int res = a + b;

            _calcDB.SetInOutData(res.ToString());
            _outputData.Value = res.ToString();                      
        }

        public void SetError()
        {
            string res = "Error";

            _calcDB.SetInOutData(res);
            _outputData.Value = res;                   
        }

        public string GetInOutData()
        {
            return _calcDB.GetInOutData();
        }

        public void SaveInputField(string inputField)
        {
            _calcDB.SetInOutData(inputField);
            PlayerPrefs.SetString(INPUT_DATA_PREFS, inputField);
        }

        public void RestoreResult()
        {
            string res = PlayerPrefs.GetString(INPUT_DATA_PREFS, "");
            _calcDB.SetInOutData(res);
            _outputData.Value = _calcDB.GetInOutData();            
        }

        
    }
}