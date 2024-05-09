using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<InventoryPrefabSO> _inventoryPrefabsSO;
    [SerializeField] private List<InteractableObject> _interactableObjects;
    [SerializeField] private Transform _spawnPlaces;

    private bool _haveBeenSpawned;
    private Player _player;

    private void Awake()
    {
        _player = GameManager.Instance.GameEntryPoint.InitPlayer();
    }

    private void OnEnable()
    {
        _player.PlayerEventsHandler.ExitGrannysHome += SpawnObjects;
    }

    private void OnDisable()
    {
        _player.PlayerEventsHandler.ExitGrannysHome -= SpawnObjects;
    }

    private void SpawnObjects()
    {
        if (!_haveBeenSpawned)
        {
            foreach (Transform spawnPlace in _spawnPlaces)
            {
                foreach (var prefab in _interactableObjects)
                {
                    Instantiate(prefab, CalculateSpawnPosition(spawnPlace), Quaternion.identity);
                }
            }

            _haveBeenSpawned = true;
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
