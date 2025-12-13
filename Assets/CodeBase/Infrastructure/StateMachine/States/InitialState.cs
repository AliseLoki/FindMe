using Assets.CodeBase.GameConfigs;
using Assets.CodeBase.Infrastructure.Data.Common;
using Assets.CodeBase.Infrastructure.DIContainer;
using Assets.CodeBase.Infrastructure.Services.Fabrica;
using Assets.CodeBase.Infrastructure.Services.Input;
using Assets.CodeBase.Infrastructure.Services.SceneLoaders;
using UnityEngine;

namespace Assets.CodeBase.Infrastructure.StateMachine.States
{
    public class InitialState : IState
    {
        private readonly DI _di;
        private readonly GameFSM _fsm;
        private readonly SceneLoader _sceneLoader;
        private readonly Configs _configs;

        public InitialState(DI di, GameFSM fsm, SceneLoader sceneLoader, Configs configs)
        {
            _di = di;
            _fsm = fsm;
            _sceneLoader = sceneLoader;
            _configs = configs;
        }

        public void Enter()
        {
            RegisterServices();
            _sceneLoader.Load(SceneNames.InitialScene, OnLoaded);
            //подумать, может вообще убрать здесь загрузку, либо наоборот добавить возможность всегла начинать с инишл сцены, но тогда нужен GameRunner
        }

        private void OnLoaded()
        {
            _fsm.ChangeState<LoadSavesState>();
        }

        private void RegisterServices()
        {
            _di.RegisterService<IInput>(SetInput());
            MonoBehaviour.print(_di.GetService<IInput>().GetType().Name);
            _di.RegisterService<IFactory>(new Factory(_di,_configs));
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
