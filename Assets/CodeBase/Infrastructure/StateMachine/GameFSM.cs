using System;
using System.Collections.Generic;
using Assets.CodeBase.Infrastructure.DIContainer;
using Assets.CodeBase.Infrastructure.StateMachine.States;
using UnityEngine;

namespace Assets.CodeBase.Infrastructure.StateMachine
{
    public class GameFSM
    {
        private readonly Dictionary<Type, IState> _states;
        private IState _currentState;

        public GameFSM(DI di)
        {
            _states = new Dictionary<Type, IState>()
            {
                [typeof(InitialState)] = new InitialState(di),
                [typeof(LoadLevelState)] = new LoadLevelState(),
                [typeof(LoadSavesState)] = new LoadSavesState(),
            };
        }

        public void ChangeState<T>() where T : IState
        {
            if (CheckIfStateExist<T>())
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

        private bool CheckIfStateExist<T>() where T : IState =>
            _states.ContainsKey(typeof(T));
    }
}
