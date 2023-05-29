using System;
using UseCases;

namespace Presenter
{
    public interface ICalcPresenter
    {
        void Initialize(ICalcUseCases calcUseCases);
        void CalcResult(string inputData);
        string GetResult();
        void AddListenerOnCalculatedResult(Action<string> result);
        void SaveInputField(string inputField);
    }
}