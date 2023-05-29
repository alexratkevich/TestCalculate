using System;
using UseCases;
using UnityEngine;
using System.Security.Cryptography;
using Gateway;

namespace UseCases
{
    public class CalcUseCases : ICalcUseCases
    {
        public Action<string> OnResultChanged { get; set; }

        private const string INPUT_DATA_PREFS = "INPUT_DATA";
        private readonly ICalcDB _calcDB;        

        public CalcUseCases(ICalcDB calcDB)
        {
            _calcDB = calcDB;
        }        

        public void CalcResult(int a, int b)
        {
            int res = a + b;

            _calcDB.SetInputData(res.ToString());

            OnResultChanged?.Invoke(res.ToString());            
        }

        public void SetError()
        {
            _calcDB.SetInputData("Error");

            OnResultChanged?.Invoke(_calcDB.GetInputData());            
        }

        public string GetResult()
        {
            return _calcDB.GetInputData();
        }

        public void SaveResult()
        {            
            PlayerPrefs.SetString(INPUT_DATA_PREFS, _calcDB.GetInputData());
        }

        public void SaveInputField(string inputField)
        {
            _calcDB.SetInputData(inputField);            
        }

        public void RestoreResult()
        {
            string res = PlayerPrefs.GetString(INPUT_DATA_PREFS, "");
            _calcDB.SetInputData(res);
            OnResultChanged?.Invoke(res);
        }        

        
    }
}