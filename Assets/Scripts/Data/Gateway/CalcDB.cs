using Entities;

namespace Gateway
{
    public class CalcDB: ICalcDB
    {
		private readonly CalcEntity _entityIputData;

        public CalcDB()
        {
            _entityIputData = new();
        }

        public void SetInOutData(string inputData)
        {
            _entityIputData.inputData = inputData;
        }

        public string GetInOutData()
        {
            return _entityIputData.inputData;
        }
    }
}