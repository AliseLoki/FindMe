using Assets.CodeBase.GameConfigs;
using Assets.CodeBase.GamePlay.Hero;
using Assets.CodeBase.GamePlay.Loot;
using Assets.CodeBase.Infrastructure.Data.Common;
using Assets.CodeBase.Infrastructure.DIContainer;
using Assets.CodeBase.Infrastructure.Services.Input;
using Assets.CodeBase.Infrastructure.Services.Interactions;
using Enemies;
using UnityEngine;

namespace Assets.CodeBase.Infrastructure.Services.Fabrica
{
    public class Factory : IFactory
    {
        private readonly DI _di;
        private readonly Configs _configs;

        public Factory(DI di, Configs configs)
        {
            _di = di;
            _configs = configs;
        }

        public Player CreatePlayer()
        {
            Player player = MonoBehaviour.Instantiate(Resources.Load<GameObject>(AssetPathes.PlayerPath)).GetComponent<Player>();
            player.Init(_di.GetService<IInput>(), _configs);
            Camera.main.GetComponent<Cameras>().Init(player.transform);
            return player;
        }

        public Enemy [] SpawnEnemies(Transform enemyPatrolPoints, Transform player)
        {
            Enemy[] newEnemies = Resources.LoadAll<Enemy>(AssetPathes.EnemyPath);
            Enemy[] spawnedEnemies  =  new Enemy [newEnemies.Length];
           
            for (int i = 0; i < newEnemies.Length; i++)
            {
              Enemy newEnemy =   MonoBehaviour.Instantiate(newEnemies[i], enemyPatrolPoints.GetChild(i).GetChild(0).transform.position, Quaternion.identity);
                newEnemy.Init(enemyPatrolPoints.GetChild(i), player);
                spawnedEnemies[i] = newEnemy;
            }

            return spawnedEnemies;
        }

        public void SpawnLoot(Transform spawnPlaces, PickableInteractionService pickableInteractionService, Transform parent)
        {
            PickableItem[] items = Resources.LoadAll<PickableItem>(AssetPathes.LootPath);

            foreach (Transform child in spawnPlaces)
            {
                foreach (var item in items)
                {
                    var newPickable = MonoBehaviour.Instantiate(item, CalculateSpawnPosition(child), Quaternion.identity, parent);
                    newPickable.Init(pickableInteractionService);
                }
            }
        }

        private Vector3 CalculateSpawnPosition(Transform transform)
        {
            var collider = transform.GetComponent<Collider>();
            float spawnPosY = 0;
            float minSpawnPosX = collider.bounds.min.x;
            float maxSpawnPosX = collider.bounds.max.x;
            float minSpawnPosZ = collider.bounds.min.z;
            float maxSpawnPosZ = collider.bounds.max.z;

            return new Vector3(Random.Range(minSpawnPosX, maxSpawnPosX), spawnPosY, Random.Range(minSpawnPosZ, maxSpawnPosZ));
        }
    }
}