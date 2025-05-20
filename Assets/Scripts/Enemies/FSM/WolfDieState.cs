using UnityEngine;
using UnityEngine.AI;

namespace Enemies
{
    public class WolfDieState : WolvesBehaviour, IState
    {
        private const string IsDying = nameof(IsDying);

        private Collider _collider;
        private GameObject _wolvesBody;

        public WolfDieState(NavMeshAgent agent, Animator animator, Collider collider, GameObject wolvesBody)
            : base(agent, animator)
        {
            _collider = collider;
            _wolvesBody = wolvesBody;
        }

        public void Enter()
        {
            SetNavMeshAgentParametres(0, 0, IsDying, true);
            _collider.enabled = false;
            _wolvesBody.gameObject.SetActive(true);
        }
    }
}