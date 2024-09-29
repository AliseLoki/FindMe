using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Village : MonoBehaviour
{
    [SerializeField] private List<House> _houses;
    [SerializeField] private InventoryPrefab _inventoryPrefab;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private ParticleSystem _effect;
    [SerializeField] private AudioClip _audioClip;

    private bool _isGivenReward;
    [SerializeField] private DeliveryService _deliveryService;
    private AudioSource _audioSource;
    [SerializeField] private TipsViewPanel _tipsViewPanel;
    [SerializeField] private Player _player;
    [SerializeField] private PlayerInventory _playerInventory;

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
