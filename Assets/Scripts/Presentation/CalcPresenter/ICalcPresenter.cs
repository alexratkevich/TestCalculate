using UseCases;
using UniRx;

namespace Presenter
{
    public interface ICalcPresenter
    {
        IReadOnlyReactiveProperty<string> OutputData { get; }

        void Initialize(ICalcUseCases calcUseCases);
        void CalcResult(string inputData);
        string GetInOutResult();        
        void SaveInputField(string inputField);
    }
}