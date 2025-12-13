using System;
using System.Collections.Generic;
using Assets.CodeBase.GameConfigs;
using Assets.CodeBase.Infrastructure.DIContainer;
using Assets.CodeBase.Infrastructure.EntryPoint;
using Assets.CodeBase.Infrastructure.Services.SceneLoaders;
using Assets.CodeBase.Infrastructure.StateMachine.States;
using UnityEngine;

namespace Assets.CodeBase.Infrastructure.StateMachine
{
    public class GameFSM
    {
        private readonly Dictionary<Type, IState> _states;
        private IState _currentState;

        public GameFSM(DI di, ICoroutineRunner coroutineRunner, SceneLoader sceneLoader, Configs configs, GameObject loadingCurtain)
        {
            _states = new Dictionary<Type, IState>()
            {
                [typeof(InitialState)] = new InitialState(di, this, sceneLoader, configs),
                [typeof(LoadSavesState)] = new LoadSavesState(sceneLoader,this),
                [typeof(LoadLevelState)] = new LoadLevelState(this,di,sceneLoader),
                [typeof(GamePlayState)] = new GamePlayState(loadingCurtain)
            };
        }

        public void ChangeState<T>() where T : IState
        {
            if (_states.ContainsKey(typeof(T)))
            {
                _currentState?.Exit();
                _currentState = _states[typeof(T)];
                _currentState.Enter();
            }
            else
            {
                Debug.LogError($"State {typeof(T)} does not exist in FSM!");
            }
        }

        public void Update()
        {
            _currentState?.Update();
        }
    }
}
