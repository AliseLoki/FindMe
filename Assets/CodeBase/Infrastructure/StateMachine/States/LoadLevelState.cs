using Assets.CodeBase.GameConfigs;
using Assets.CodeBase.GamePlay.Hero;
using Assets.CodeBase.Infrastructure.Data.Common;
using Assets.CodeBase.Infrastructure.DIContainer;
using Assets.CodeBase.Infrastructure.Services.Fabrica;
using Assets.CodeBase.Infrastructure.Services.Input;
using Assets.CodeBase.Infrastructure.Services.SceneLoaders;
using UnityEngine;

namespace Assets.CodeBase.Infrastructure.StateMachine.States
{
    public class LoadLevelState : IState
    {
        private readonly GameFSM _fsm;
        private readonly DI _di;
        private readonly SceneLoader _sceneLoader;

        private  IFactory _factory;

        public LoadLevelState(GameFSM fsm, DI di, SceneLoader sceneLoader)
        {
            _fsm = fsm;
            _di = di;
            _sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            _factory = _di.GetService<IFactory>();

            MonoBehaviour.print("ENterLoadLevelState");
            _sceneLoader.Load(SceneNames.GrannysHomeScene, OnLoaded);
        }

        private void OnLoaded()
        {
            _factory.CreatePlayer();

            _fsm.ChangeState<GamePlayState>();
        }

        public void Exit()
        {
            MonoBehaviour.print("ExitLoadLevelState");
        }

        public void Update()
        {

        }
    }
}
