using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace CalcView
{
    public class CalculatorView : MonoBehaviour
    {
        [SerializeField]
        private InputField inputEquation;
        [SerializeField]
        private Button resultButton;
        [SerializeField]
        private Image loadingImage;

        public string ResultValue => inputEquation.text;

        public event Action ClickResult;

        public void Initialize()
        {
            resultButton.onClick.AddListener(() => OnClickResult());            
            Loading();
        }

        private void OnClickResult()
        {
            ClickResult?.Invoke();
        }


        private async void Loading()
        {
            await Task.Delay(2000);            
            loadingImage.gameObject.SetActive(false);

        }

        public string GetResult()
        {
            if (IsEquationValid(inputEquation.text))
            {
                GetInputs(inputEquation.text, out int input1, out int input2);
                Debug.Log($"Calculate result");
                return SumEquation(input1, input2).ToString();
            }
            else
                return "Error";
        }

        private bool IsEquationValid(string equation)
        {
            string[] inputs = SplitEquation(equation);

            if (inputs.Length != 2)
                return false;
            else
            {
                if (!int.TryParse(inputs[0], out int input1))
                    return false;
                if (!int.TryParse(inputs[1], out int input2))
                    return false;
            }

            return true;
        }

        private void GetInputs(string equation, out int input1, out int input2)
        {
            string[] inputs = SplitEquation(equation);

            input1 = int.Parse(inputs[0]);
            input2 = int.Parse(inputs[1]);
        }

        private int SumEquation(int a, int b)
        {
            Debug.Log($"SumEquation(). a = {a}, b = {b}");
            return a + b;
        }

        private string[] SplitEquation(string equation)
        {
            return equation.Replace(" ", "").Split("+");
        }

        public void ShowResult(string result)
        {
            Debug.Log($"ShowResult(). result = {result}");
            inputEquation.text = result;
        }


    }
}