using UnityEngine;

namespace Assets.CodeBase.Infrastructure.StateMachine.States
{
    public class GamePlayState : IState
    {
        private readonly GameObject _loadingCurtain;

        public GamePlayState(GameObject loadingCurtain)
        {
            _loadingCurtain = loadingCurtain;
        }

        public void Enter()
        {
            // сначала находим объект на карте который будет отвечать за весь геймплей
            Hide();
        }

        public void Exit()
        {
           
        }

        public void Update()
        {
           
        }

        private void Hide()
        {
            _loadingCurtain.SetActive(false);
        }
    }
}
