using DeliveryServiceHandler;
using Interactables;
using Interactables.InventoryPrefabs;
using System.Collections.Generic;
using UnityEngine;
using PlayerController;
using Indexes;

namespace Villages
{
    [RequireComponent(typeof(AudioSource))]
    public class Village : MonoBehaviour
    {
        [SerializeField] private List<House> _houses;
        [SerializeField] private InventoryPrefab _inventoryPrefab;
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private ParticleSystem _effect;
        [SerializeField] private AudioClip _audioClip;
        [SerializeField] private DeliveryService _deliveryService;
        [SerializeField] private TipsViewPanel _tipsViewPanel;
        [SerializeField] private Player _player;
        [SerializeField] private PlayerInventory _playerInventory;

        [SerializeField] private VillageIndex _villageIndex;

        private bool _isGivenReward;
        private AudioSource _audioSource;

        public VillageIndex Index => _villageIndex;
        public bool IsGivenReward => _isGivenReward;

        public Transform SpawnPoint => _spawnPoint;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        private void OnEnable()
        {
            _deliveryService.AllDishesHaveBeenDelivered += OnAllDishesHaveBeenDelivered;
        }

        private void OnDisable()
        {
            _deliveryService.AllDishesHaveBeenDelivered -= OnAllDishesHaveBeenDelivered;
        }

        public void SetIsGivenReward(bool isGiven)
        {
            _isGivenReward = isGiven;
        }

        public virtual void GiveReward()
        {
            var rewardForDeliveryTest = Instantiate(_inventoryPrefab, _spawnPoint.position, Quaternion.identity, _spawnPoint);
            rewardForDeliveryTest.InitLinks(_tipsViewPanel, _player, _playerInventory);
            _effect.Play();
        }

        private void OnAllDishesHaveBeenDelivered()
        {
            if (CheckIfDelivered() && !_isGivenReward)
            {
                _audioSource.PlayOneShot(_audioClip);
                GiveReward();
                _tipsViewPanel.ShowTakeRewardTip();
                _isGivenReward = true;
            }
        }

        private bool CheckIfDelivered()
        {
            foreach (House house in _houses)
            {
                if (!house.IsDelivered)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
