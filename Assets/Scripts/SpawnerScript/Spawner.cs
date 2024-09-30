using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<InteractableObject> _interactableObjects;

    [SerializeField] private Transform _bucketOfWater;
    [SerializeField] private Wood _wood;
    [SerializeField] private Sword _sword;
    [SerializeField] private Cow _cow;
    [SerializeField] private CabbageForSeeds _cabbageForSeeds;
    [SerializeField] private TomatoForSeeds _tomatoForSeeds;
    [SerializeField] private Necronomicon _necronomicon;

    [SerializeField] private Transform _spawnPlaces;
    [SerializeField] private Transform _woodSpawnPlace;
    [SerializeField] private PresentFromAd _presentFromAd;

    [SerializeField] private Player _player;
    [SerializeField] private GameStatesSwitcher _gameStatesSwitcher;
    [SerializeField] private TipsViewPanel _tipsViewPanel;

    private Vector3 _offset = new Vector3(0, -1.7f, 2);
    private bool _haveBeenSpawned;

    private void OnEnable()
    {
        _player.PlayerEventsHandler.ExitGrannysHome += SpawnObjects;
    }

    private void Start()
    {
        if (_gameStatesSwitcher.IsFirstStart)
        {
            Instantiate(_wood, _woodSpawnPlace.position, Quaternion.identity);
        }
    }

    private void OnDisable()
    {
        _player.PlayerEventsHandler.ExitGrannysHome -= SpawnObjects;
    }

    public void SpawnBucketOfWater(Transform spawnPoint)
    {
        var waterInHands = Instantiate(_bucketOfWater, spawnPoint, true);
        waterInHands.transform.position = spawnPoint.position;
    }

    public InventoryPrefabSO SpawnNecronomicon()
    {
        var necronomicon = Instantiate(_necronomicon);
        return necronomicon.DisableCollider();
    }

    public void SpawnWoodInHands()
    {
        var wood = Instantiate(_wood);
        //wood.DisableCollider();
    }

    public InventoryPrefabSO SpawnSwordInHands()
    {
        var sword = Instantiate(_sword);
        return sword.DisableCollider();
    }

    public InventoryPrefabSO SpawnCowInHands()
    {
        var cow = Instantiate(_cow);
        return cow.DisableCollider();
    }

    public InventoryPrefabSO SpawnCabbageForSeedsInHands()
    {
        var cabbageForSeeds = Instantiate(_cabbageForSeeds);
        return cabbageForSeeds.DisableCollider();
    }

    public InventoryPrefabSO SpawnTomatoForSeedsInHands()
    {
        var tomatoForSeeds = Instantiate(_tomatoForSeeds);
        return tomatoForSeeds.DisableCollider();
    }

    public void GiveRewardForWatchingAd()
    {
        var presentFromAd = Instantiate(_presentFromAd, _player.HandlePoint.position + _offset, Quaternion.identity);
        presentFromAd.InitLinks(_tipsViewPanel, _player, _player.PlayerInventory);
    }

    private void SpawnObjects()
    {
        if (!_haveBeenSpawned)
        {
            foreach (Transform spawnPlace in _spawnPlaces)
            {
                foreach (var interactableObject in _interactableObjects)
                {
                    var newSpawnedInteractableObject = Instantiate(interactableObject, CalculateSpawnPosition(spawnPlace), Quaternion.identity);
                    newSpawnedInteractableObject.InitLinks(_tipsViewPanel, _player, _player.PlayerInventory);
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
