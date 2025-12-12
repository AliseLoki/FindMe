using System;
using UnityEngine;

namespace Assets.CodeBase.Infrastructure.StateMachine.States
{
    public class LoadLevelState : IState
    {
        public void Enter()
        {
            MonoBehaviour.print("LoadLevelEnter");
        }

        public void Exit()
        {
            
        }

        public void Update()
        {
            
        }
    }
}
