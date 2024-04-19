using static GameManager;
using UnityEngine;
using Unity.VisualScripting.FullSerializer;

namespace FSM.Scripts
{
    public class FsmStateWaiting : FsmState
    {
        private float _waitingToStartTimer = 1f;

        public FsmStateWaiting(Fsm fsm) : base(fsm)
        {

        }

        public override void Enter()
        {
            Debug.Log("EnterWaiting");
        }

        public override void Exit()
        {

        }

        public override void Update()
        {
            _waitingToStartTimer -= Time.deltaTime;

            if (_waitingToStartTimer < 0f)
            {
                Fsm.SetState<FsmStateCountdownToStart>();
            }
        }
    }
}

