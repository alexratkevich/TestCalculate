using UniRx;

namespace UseCases
{
    public interface ICalcUseCases
    {        
        IReadOnlyReactiveProperty<string> OutputData { get; }
        void CalcResult(int a, int b);
        void SetError();
        string GetInOutData();
        void SaveInputField(string inputField);        
        void RestoreResult();
    }

}