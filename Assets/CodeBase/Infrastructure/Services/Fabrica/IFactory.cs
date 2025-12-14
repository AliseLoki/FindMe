using Assets.CodeBase.GamePlay.Hero;
using Assets.CodeBase.Infrastructure.Services.Interactions;
using UnityEngine;

namespace Assets.CodeBase.Infrastructure.Services.Fabrica
{
    public interface IFactory : IService
    {
        Player CreatePlayer();
        void SpawnLoot(Transform transform, PickableInteractionService pickableInteractionService, Transform parent);
    }
}
