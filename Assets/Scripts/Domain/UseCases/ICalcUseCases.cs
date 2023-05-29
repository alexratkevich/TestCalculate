using System;

namespace UseCases
{
    public interface ICalcUseCases
    {
        Action<string> OnResultChanged { get; set; }
        void CalcResult(int a, int b);
        void SetError();
        string GetResult();
        void SaveInputField(string inputField);
        void SaveResult();
        void RestoreResult();
    }

}