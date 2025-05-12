using UnityEngine;
using UnityEngine.AI;

namespace Enemies
{
    public abstract class WolvesBehaviour
    {
        protected NavMeshAgent Agent;
        protected Animator Animator;

        protected WolvesBehaviour(NavMeshAgent agent, Animator animator)
        {
            Animator = animator;
            Agent = agent;
        }

        protected void SetNavMeshAgentParametres(float stoppingDistance, float speed, string currentAnimation, bool isMoving)
        {
            Agent.stoppingDistance = stoppingDistance;
            Agent.isStopped = isMoving;
            Agent.speed = speed;
            Animator.SetTrigger(currentAnimation);
        }
    }
}