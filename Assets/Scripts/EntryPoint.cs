using UnityEngine;
using System.Collections;
using Presenter;
using Gateway;
using UseCases;

namespace Entrypoints
{
    public class EntryPoint : MonoBehaviour
    {
        public static ICalcPresenter _calcPresenter;

        // Use this for initialization
        void Awake()
        {
            _calcPresenter = gameObject.GetComponent<CalcPresenter>();
            ICalcDB calcDB = new CalcDB();
            ICalcUseCases calcUseCases = new CalcUseCases(calcDB);
            _calcPresenter.Initialize(calcUseCases);
        }

    }
}