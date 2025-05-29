using System;
using System.Collections.Generic;

namespace Enemies
{
    public class EnemyStateMachine
    {
        private Dictionary<Type, IState> _states = new Dictionary<Type, IState>();
        private IState StateCurrent { get; set; }

        public void AddState(IState state)
        {
            _states.Add(state.GetType(), state);
        }

        public void SetState<T>()
            where T : IState
        {
            var type = typeof(T);

            if (StateCurrent != null && StateCurrent.GetType() == type)
            {
                return;
            }

            if (_states.TryGetValue(type, out var newState))
            {
                StateCurrent?.Exit();
                StateCurrent = newState;
                StateCurrent.Enter();
            }
        }

        public void Update()
        {
            StateCurrent?.Update();
        }
    }
}