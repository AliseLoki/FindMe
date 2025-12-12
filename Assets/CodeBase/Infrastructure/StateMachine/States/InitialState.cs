using Assets.CodeBase.Infrastructure.DIContainer;
using Assets.CodeBase.Infrastructure.Services.Fabrica;
using Assets.CodeBase.Infrastructure.Services.Input;
using UnityEngine;

namespace Assets.CodeBase.Infrastructure.StateMachine.States
{
    public class InitialState : IState
    {
        private readonly DI _di;

        public InitialState(DI di)
        {
            _di = di;
            RegisterServices();
        }

        public void Enter()
        {
            // следующтй загрузили сохраненное
            // следующий стейт создалт префабы
        }

        private void RegisterServices()
        {
            _di.RegisterService<IInput>(SetInput());
            MonoBehaviour.print(_di.GetService<IInput>().GetType().Name);
            _di.RegisterService<IFactory>(new Factory());
            MonoBehaviour.print(_di.GetService<IFactory>().GetType().Name);
        }

        public void Exit()
        {
            MonoBehaviour.print("InitialExit");
        }

        public void Update()
        {

        }

        private IInput SetInput() =>
            Application.isMobilePlatform ? new MobileInput() : new DesktopInput();
    }
}
