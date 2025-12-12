using Assets.CodeBase.GamePlay.Hero;
using Assets.CodeBase.Infrastructure.Data.Common;
using UnityEngine;

namespace Assets.CodeBase.Infrastructure.Services.Fabrica
{
    public class Factory : IFactory
    {
        public Factory()
        {

        }
        //Player pl = player.GetComponent<Player>();
        //pl.Init(_di.GetService<IInput>());

        public void CreatePlayer()
        {

           // Player player = MonoBehaviour.Instantiate(Resources.Load<GameObject>(AssetPathes.PlayerPath)).GetComponent<Player>();
        }
    }
}
