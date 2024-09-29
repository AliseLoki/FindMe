using Unity.VisualScripting;
using UnityEngine;

public class Patch : InteractableObject
{
    [SerializeField] private InventoryPrefabSO _inventoryPrefabSO;
    [SerializeField] private Transform _grass;
    [SerializeField] private Transform _vegetable;
    [SerializeField] private Container _barrelWithIngredients;

    private bool _seedIsLanded;

    private void Start()
    {
        if (_grass.gameObject.activeSelf)
        {
            _seedIsLanded = true;
        }
    }

    protected override void UseObject()
    {
        int wateringSoundEffectIndex = 0;
        int throwingSoundEffect = 1;

        if (_seedIsLanded && Player.PlayerHands.HasWater)
        {
            PlaySoundEffect(AudioClipsList[wateringSoundEffectIndex]);
            Player.GiveWater();
            _vegetable.gameObject.SetActive(true);
            _barrelWithIngredients.gameObject.SetActive(true);
            ShowYouHaveNewIngredientTips();
        }
        else if (Player.PlayerHands.HasSeed && Player.SetInventoryPrefabSO() == _inventoryPrefabSO)
        {
            PlaySoundEffect(AudioClipsList[throwingSoundEffect]);
            Player.LandSeed();
            _seedIsLanded = true;
            _grass.gameObject.SetActive(true);
            DisableInteract();
            ShowBringWaterTip();
        }
        else if (Player.PlayerHands.HasWater)
        {
            PlaySoundEffect(AudioClipsList[wateringSoundEffectIndex]);
            Player.GiveWater();
        }
    }

    private void ShowYouHaveNewIngredientTips()
    {
        if (_inventoryPrefabSO.InventoryPrefab as Cow)
        {
            TipsViewPanel.ShowNowYouHaveCheeseTip();
        }
        else if (_inventoryPrefabSO.InventoryPrefab as CabbageForSeeds || _inventoryPrefabSO.InventoryPrefab as TomatoForSeeds)
        {
            TipsViewPanel.ShowNowYouHaveNewVegetableTip();
        }
    }

    private void ShowBringWaterTip()
    {
        if (_inventoryPrefabSO.InventoryPrefab as Cow)
        {
            TipsViewPanel.ShowGiveMeAWaterTip();
        }
        else if (_inventoryPrefabSO.InventoryPrefab as CabbageForSeeds || _inventoryPrefabSO.InventoryPrefab as TomatoForSeeds)
        {
            TipsViewPanel.ShowBringWaterHere();
        }
    }
}
