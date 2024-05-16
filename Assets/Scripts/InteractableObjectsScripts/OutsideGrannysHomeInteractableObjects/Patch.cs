using UnityEngine;

public class Patch : InteractableObject
{
    [SerializeField] private InventoryPrefabSO _inventoryPrefabSO;
    [SerializeField] private Transform _grass;
    [SerializeField] private Transform _vegetable;
    [SerializeField] private Container _barrelWithVegetables;

    private bool _seedIsLanded;

    protected override void UseObject()
    {
        int wateringSoundEffectIndex = 0;
        int throwingSoundEffect = 1;

        if (_seedIsLanded && Player.HasWater)
        {
            PlaySoundEffect(AudioClipsList[wateringSoundEffectIndex]);
            _vegetable.gameObject.SetActive(true);
            Player.GiveWater();
            _barrelWithVegetables.gameObject.SetActive(true);
            ShowYouHaveNewIngredientTips();
        }
        else if (Player.HasSeed && Player.SetInventoryPrefabSO() == _inventoryPrefabSO)
        {
            PlaySoundEffect(AudioClipsList[throwingSoundEffect]);
            _grass.gameObject.SetActive(true);
            Player.LandSeed();
            _seedIsLanded = true;
            DisableInteract();
            ShowBringWaterTip();
        }
        else if (Player.HasWater)
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
