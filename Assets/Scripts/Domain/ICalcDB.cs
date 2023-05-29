using System;

namespace Gateway
{
    public interface ICalcDB
    {
        void SetInputData(string inputtData);
        string GetInputData();
    }
}
