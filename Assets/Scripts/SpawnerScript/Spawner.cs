using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<InteractableObject> _interactableObjects;

    [SerializeField] private BucketOfWater _bucketOfWater;
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
    [SerializeField] private TipsViewPanel _tipsViewPanel;

    private Vector3 _offset = new Vector3(0, -1.7f, 2);
    private bool _haveBeenSpawned;
    
    private void Start()
    {
        SpawnObjects();

        //только если ферстстарт
       // Instantiate(_wood, _woodSpawnPlace.position, Quaternion.identity);
    }


    //не забыть заспаунить ведро в колодце
    public void SpawnBucketOfWaterInHands()
    {
        SpawnHoldableObject(_bucketOfWater);
    }

    public void SpawnWoodInHands()
    {
        SpawnHoldableObject(_wood);
    }

    public void SpawnSwordInHands()
    {
        SpawnHoldableObject(_sword);
    }

    private void SpawnHoldableObject(InteractableObject objectInHands)
    {
        var spawnedObject = Instantiate(objectInHands);
        spawnedObject.InitLinks(_tipsViewPanel, _player, _player.PlayerInventory);
        spawnedObject.DisableCollider();
        _player.PlayerHands.TakeObject(spawnedObject.gameObject,spawnedObject.HoldableObjects);
    }

    public InventoryPrefabSO SpawnNecronomicon()
    {
        var necronomicon = Instantiate(_necronomicon);
        necronomicon.InitLinks(_tipsViewPanel, _player, _player.PlayerInventory);
        return necronomicon.DisableColliders();
    }

    public InventoryPrefabSO SpawnCowInHands()
    {
        var cow = Instantiate(_cow);
        cow.InitLinks(_tipsViewPanel, _player, _player.PlayerInventory);
        return cow.DisableColliders();
    }

    public InventoryPrefabSO SpawnCabbageForSeedsInHands()
    {
        var cabbageForSeeds = Instantiate(_cabbageForSeeds);
        cabbageForSeeds.InitLinks(_tipsViewPanel, _player, _player.PlayerInventory);
        return cabbageForSeeds.DisableColliders();
    }

    public InventoryPrefabSO SpawnTomatoForSeedsInHands()
    {
        var tomatoForSeeds = Instantiate(_tomatoForSeeds);
        tomatoForSeeds.InitLinks(_tipsViewPanel, _player, _player.PlayerInventory);
        return tomatoForSeeds.DisableColliders();
    }

    public void GiveRewardForWatchingAd()
    {
        var presentFromAd = Instantiate(_presentFromAd, _player.PlayerHands.HandlePoint.position + _offset, Quaternion.identity);
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
