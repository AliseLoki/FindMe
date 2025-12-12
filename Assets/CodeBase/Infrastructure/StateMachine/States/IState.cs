namespace Assets.CodeBase.Infrastructure.StateMachine.States
{
    public interface IState
    {
        void Enter();
        void Update();
        void Exit();
    }
}
