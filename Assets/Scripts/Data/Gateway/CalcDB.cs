using System;
using Entities;
namespace Gateway
{
    public class CalcDB: ICalcDB
    {
		private readonly CalcEntity _entityIpudData;

        public CalcDB()
        {
            _entityIpudData = new();
        }

        public void SetInputData(string inputData)
        {
            _entityIpudData.inputData = inputData;
        }

        public string GetInputData()
        {
            return _entityIpudData.inputData;
        }
    }
}