using Assets.CodeBase.GameConfigs;
using Assets.CodeBase.GamePlay.Hero;
using Assets.CodeBase.Infrastructure.Data.Common;
using Assets.CodeBase.Infrastructure.DIContainer;
using Assets.CodeBase.Infrastructure.Services.Input;
using UnityEngine;

namespace Assets.CodeBase.Infrastructure.Services.Fabrica
{
    public class Factory : IFactory
    {
        private readonly DI _di;
        private readonly Configs _configs;

        private Player _player;

        public Factory(DI di, Configs configs)
        {
            _di = di;
            _configs = configs;
        }

        public void CreatePlayer()
        {
            _player = MonoBehaviour.Instantiate(Resources.Load<GameObject>(AssetPathes.PlayerPath)).GetComponent<Player>();
            _player.Init(_di.GetService<IInput>(), _configs);
            Camera.main.GetComponent<Cameras>().Init(_player.transform);
        }
    }
}