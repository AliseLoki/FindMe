using Assets.CodeBase.Infrastructure.Services.SceneLoaders;
using UnityEngine;

namespace Assets.CodeBase.Infrastructure.StateMachine.States
{
    public class LoadSavesState : IState
    {
        private readonly SceneLoader _sceneLoader;
        private readonly GameFSM _fsm;

        public LoadSavesState(SceneLoader sceneLoader, GameFSM fsm)
        {
            _sceneLoader = sceneLoader;
            _fsm = fsm;
        }

        public void Enter()
        {
            MonoBehaviour.print("ENterLoadSavesState");
            _fsm.ChangeState<LoadLevelState>();
        }

        public void Exit()
        {
            MonoBehaviour.print("EXITLOadSaves");
        }

        public void Update()
        {

        }
    }
}
