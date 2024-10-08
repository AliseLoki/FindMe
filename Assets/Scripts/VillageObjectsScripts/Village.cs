using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Village : MonoBehaviour
{
    [SerializeField] private List<House> _houses;
    [SerializeField] private List<House> _housesWithDeliveredDish;

    [SerializeField] private InventoryPrefab _inventoryPrefab;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private ParticleSystem _effect;
    [SerializeField] private AudioClip _audioClip;
    [SerializeField] private DeliveryService _deliveryService;
    [SerializeField] private TipsViewPanel _tipsViewPanel;
    [SerializeField] private Player _player;
    [SerializeField] private PlayerInventory _playerInventory;

    private bool _isGivenReward;
    private AudioSource _audioSource;

    public List<House> HousesWithDeliveredDish => _housesWithDeliveredDish;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        
    }

    private void OnEnable()
    {
        _deliveryService.AllDishesHaveBeenDelivered += OnAllDishesHaveBeenDelivered;
    }

    private void OnDisable()
    {
        _deliveryService.AllDishesHaveBeenDelivered -= OnAllDishesHaveBeenDelivered;
    }

    public void LoadHousesWithDeliveredDish(List<House> housesWithDeliveredDish)
    {
        _housesWithDeliveredDish = housesWithDeliveredDish;
    }

    public void AddHouseInList(House house)
    {
        _housesWithDeliveredDish.Add(house);
    }

    protected virtual void GiveReward()
    {
        var rewardForDelivery = Instantiate(_inventoryPrefab, _spawnPoint.position, Quaternion.identity);
        rewardForDelivery.InitLinks(_tipsViewPanel, _player, _playerInventory);
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
