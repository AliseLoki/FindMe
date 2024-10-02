using UnityEngine;

public class Patch : InteractableObject
{
    [SerializeField] private InventoryPrefabSO _inventoryPrefabSO;
    [SerializeField] private Transform _grass;
    [SerializeField] private Transform _vegetable;
    [SerializeField] private Container _barrelWithIngredients;

    private bool _seedIsLanded;
   
    public void SeedIsLanded()
    {
        _seedIsLanded = true;
    }

    protected override void UseObject()
    {
        int wateringSoundEffectIndex = 0;
        int throwingSoundEffect = 1;

        if (_seedIsLanded && Player.PlayerHands.HoldableObject == HoldableObjects.Water)
        {
            PlaySoundEffect(AudioClipsList[wateringSoundEffectIndex]);
            Player.PlayerHands.GiveObject();
            _vegetable.gameObject.SetActive(true);
            _barrelWithIngredients.gameObject.SetActive(true);
            ShowYouHaveNewIngredientTips();
        }
        else if (Player.PlayerHands.HoldableObject == HoldableObjects.CabbageForSeeds
            || Player.PlayerHands.HoldableObject == HoldableObjects.TomatoForSeeds
            && Player.PlayerHands.InventoryPrefabSO == _inventoryPrefabSO)
        {
            PlaySoundEffect(AudioClipsList[throwingSoundEffect]);
            Player.PlayerHands.GiveObject();
            _seedIsLanded = true;
            _grass.gameObject.SetActive(true);
            DisableInteract();
            ShowBringWaterTip();
        }
        else if (Player.PlayerHands.HoldableObject == HoldableObjects.Water)
        {
            PlaySoundEffect(AudioClipsList[wateringSoundEffectIndex]);
            Player.PlayerHands.GiveObject();
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
