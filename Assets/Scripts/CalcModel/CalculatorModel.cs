using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CalcModel
{
    public class CalculatorModel
    {
        private const string EQUATION_KEY = "equation";
        public string equationValue;

        public CalculatorModel()
        {
            LoadData();
        }        

        public void SaveData()
        {
            Debug.Log("SaveData()");
            PlayerPrefs.SetString(EQUATION_KEY, equationValue);
        }

        public void LoadData()
        {
            Debug.Log("LoadData()");
            equationValue = PlayerPrefs.GetString(EQUATION_KEY, "");
        }
    }
}