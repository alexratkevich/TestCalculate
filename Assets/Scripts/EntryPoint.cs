using Presenter;
using Gateway;
using UseCases;
using Zenject;

namespace Entrypoints
{
    public class EntryPoint : MonoInstaller
    {
        public static ICalcPresenter _calcPresenter;

        public override void InstallBindings()
        {
            var gateway = new CalcDB();
            var usecase = new CalcUseCases(gateway);
            var presenter = gameObject.AddComponent<CalcPresenter>();
            presenter.Initialize(usecase);

            // And assign for injection
            Container
                .Bind<ICalcDB>()
                .FromInstance(gateway);

            Container
                .Bind<ICalcUseCases>()
                .FromInstance(usecase);

            Container
                .Bind<ICalcPresenter>()
                .FromInstance(presenter);
        }          
    }
}