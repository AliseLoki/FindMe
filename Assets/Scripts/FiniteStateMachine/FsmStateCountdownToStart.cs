using static GameManager;
using UnityEngine;

namespace FSM.Scripts
{
    public class FsmStateCountdownToStart : FsmState
    {
        private float _countdownToStartTimer = 5f;

        public FsmStateCountdownToStart(Fsm fsm) : base(fsm)
        {

        }

        public override void Enter()
        {
            
        }

        public override void Exit()
        {

        }

        public override void Update()
        {
            _countdownToStartTimer -= Time.deltaTime;

            if (_countdownToStartTimer < 0f)
            {
                
            }
        }
    }
}

