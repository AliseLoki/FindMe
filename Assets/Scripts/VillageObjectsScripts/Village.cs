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
    private DeliveryService _deliveryService;
    private AudioSource _audioSource;
    private TipsViewPanel _tipsViewPanel;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _deliveryService = GameManager.Instance.GameEntryPoint.InitDeliveryService();
        _tipsViewPanel = GameManager.Instance.GameEntryPoint.InitTipsViewPanel();
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
        Instantiate(_inventoryPrefab, _spawnPoint.position, Quaternion.identity);
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
