using System.Collections.Generic;
using Enemies;
using GameControllers;
using Indexies;
using Interactables;
using Interactables.InventoryPrefabs;
using PlayerController;
using SO;
using SoundSystem;
using UnityEngine;

namespace SaveSystem
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private List<InteractableObject> _interactableObjects;
        [SerializeField] private List<HoldableObjectSO> _holdableObjectsSO;
        [SerializeField] private BucketOfWater _bucketOfWater;
        [SerializeField] private Wood _wood;
        [SerializeField] private InventoryPrefab _necronomicon;
        [SerializeField] private Witch _witch;
        [SerializeField] private Transform _placeForBucketOfWaterInWell;
        [SerializeField] private Transform _spawnPlaces;
        [SerializeField] private Transform _woodSpawnPlace;
        [SerializeField] private Transform _necronomiconSpawnPlace;
        [SerializeField] private Transform _witchSpawnPlace;
        [SerializeField] private PresentFromAd _presentFromAd;
        [SerializeField] private PlayerOld _player;
        [SerializeField] private GameStatesSwitcher _gameStatesSwitcher;
        [SerializeField] private Music _music;

        private Vector3 _offset = new Vector3(0, -1.7f, 2);
        private bool _haveBeenSpawned;

        private void Start()
        {
            SpawnObjects();
            SpawnNecronomicon();

            if (_gameStatesSwitcher.IsFirstStart)
            {
                var wood = Instantiate(_wood, _woodSpawnPlace.position, Quaternion.identity);
                wood.InitLinks(_player, _player.PlayerInventory);
            }
        }

        public BucketOfWater SpawnBucketOfWaterInWell()
        {
            return Instantiate(_bucketOfWater, _placeForBucketOfWaterInWell.position, Quaternion.identity);
        }

        public void SpawnHoldableObjectInHands(HoldableObjectType holdableObjectType)
        {
            foreach (var item in _holdableObjectsSO)
            {
                if (item.Type == holdableObjectType)
                {
                    var spawnedObject = Instantiate(item.Prefab);

                    if (spawnedObject.TryGetComponent(out InteractableObject interactableObject))
                    {
                        interactableObject.InitLinks(_player, _player.PlayerInventory);
                        interactableObject.DisableCollider();
                    }
                    else if (spawnedObject.TryGetComponent(out Food food))
                    {
                        _player.PlayerCookingModule.SetFood(food, food.ConnectedFoodSO);
                    }

                    _player.PlayerHands.TakeObject(spawnedObject.gameObject, holdableObjectType);
                    break;
                }
            }
        }

        public void GiveRewardForWatchingAd()
        {
            var presentFromAd = Instantiate(_presentFromAd, _player.PlayerHands.HandlePoint.position + _offset, Quaternion.identity);
            presentFromAd.InitLinks(_player, _player.PlayerInventory);
        }

        public Witch SpawnWitch()
        {
            Witch witch = Instantiate(_witch, _witchSpawnPlace.position, Quaternion.identity);
            witch.InitLinks(_music, _player);

            return witch;
        }

        private void SpawnNecronomicon()
        {
            if (_player.PlayerInventory.RecievedInventoryPrefabSO.Contains(_necronomicon.ConnectedInentoryPrefabSO) == false)
            {
                var necronomicon = Instantiate(_necronomicon, _necronomiconSpawnPlace.position, Quaternion.identity);
                necronomicon.InitLinks(_player, _player.PlayerInventory);
            }
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

                        newSpawnedInteractableObject.InitLinks(_player, _player.PlayerInventory);
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
}