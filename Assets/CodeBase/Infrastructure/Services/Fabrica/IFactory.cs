using Assets.CodeBase.GamePlay.Hero;
using Assets.CodeBase.Infrastructure.Services.Interactions;
using Enemies;
using UnityEngine;

namespace Assets.CodeBase.Infrastructure.Services.Fabrica
{
    public interface IFactory : IService
    {
        Player CreatePlayer();
        Enemy []  SpawnEnemies(Transform enemyPatrolPoints, Transform player);
        void SpawnLoot(Transform transform, PickableInteractionService pickableInteractionService, Transform parent);
    }
}
