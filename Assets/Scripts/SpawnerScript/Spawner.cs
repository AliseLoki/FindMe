using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<InteractableObject> _interactableObjects;

    [SerializeField] private Wood _wood;
    [SerializeField] private Sword _sword;
    [SerializeField] private Cow _cow;
    [SerializeField] private CabbageForSeeds _cabbageForSeeds;
    [SerializeField] private TomatoForSeeds _tomatoForSeeds;

    [SerializeField] private Transform _spawnPlaces;
    [SerializeField] private Transform _woodSpawnPlace;
    [SerializeField] private PresentFromAd _presentFromAd;

    private Vector3 _offset = new Vector3(0, -1.7f, 2);
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

    private void Start()
    {
        if (GameManager.Instance.IsFirstStart)
        {
            Instantiate(_wood, _woodSpawnPlace.position, Quaternion.identity);
        }
    }

    private void OnDisable()
    {
        _player.PlayerEventsHandler.ExitGrannysHome -= SpawnObjects;
    }

    public void SpawnWoodInHands()
    {
        var wood = Instantiate(_wood);
        wood.DisableCollider();
    }

    public InventoryPrefabSO SpawnSwordInHands()
    {
       var sword = Instantiate(_sword);
      return  sword.DisableCollider();
    }

    public InventoryPrefabSO SpawnCowInHands()
    {
        var cow = Instantiate(_cow);
       return cow.DisableCollider();
    }

    public InventoryPrefabSO SpawnCabbageForSeedsInHands( )
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
        Instantiate(_presentFromAd, _player.HandlePoint.position + _offset, Quaternion.identity);
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
