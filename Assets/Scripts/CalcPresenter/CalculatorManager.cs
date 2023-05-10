using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using CalcView;
using CalcModel;

namespace CalcPresenter
{
    public class CalculatorManager : MonoBehaviour
    {
        [SerializeField]
		private CalculatorView calculatorView;
		private CalculatorModel calculatorModel;
		

		// Start is called before the first frame update
		void Awake()
        {
            Initialize();
        }

        private void Initialize()
        {
            calculatorView.Initialize();
            calculatorView.ClickResult += OnCalculateClick;

            if (calculatorModel == null)
                calculatorModel = new CalculatorModel();

            calculatorView.ShowResult(calculatorModel.equationValue);
        }

        private void OnApplicationQuit()
        {
            Debug.Log("OnApplicationQuit");
            SaveState();
        }

        private void OnApplicationFocus(bool hasFocus)
        {
            Debug.Log("OnApplicationFocus");
            if (!hasFocus)
                SaveState();
            
        }

        //private void OnApplicationPause(bool hasPause)
        //{
        //    Debug.Log("OnApplicationPause");
        //    if (hasPause)
        //        SaveState();
        //    //else
        //    //    Initialize();
        //}

        private void SaveState()
        {
            calculatorModel.equationValue = calculatorView.ResultValue;
            calculatorModel.SaveData();
        }

        private void OnCalculateClick()
        {
            var result = calculatorView.GetResult();
            calculatorView.ShowResult(result);
        }

        

    }

}