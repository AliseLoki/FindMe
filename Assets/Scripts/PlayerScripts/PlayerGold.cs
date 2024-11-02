using System;
using UnityEngine;

public class PlayerGold : MonoBehaviour
{
    private int _gold;
    
    [SerializeField] private Player _player;
    
    public int Gold => _gold;

    public event Action<int> GoldAmountChanged;

    public void GetGold(int gold)
    {
        _gold = gold;
        GoldAmountChanged?.Invoke(_gold);
    }

    public void OnGoldAmountChanged(int goldChangeValue)
    {
        _player.PlayerSoundEffects.PlayTakingGoldSoundEffect();
        _gold += goldChangeValue;
        GoldAmountChanged?.Invoke(_gold);
    }
    
    public bool CheckIfCanPay(int price)
    {
        if (_gold >= price)
        {
            _gold -= price;
            GoldAmountChanged?.Invoke(_gold);
            return true;
        }

        return false;
    }
}
