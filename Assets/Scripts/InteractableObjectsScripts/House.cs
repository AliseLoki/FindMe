using System.Collections;
using UnityEngine;

public class House : InteractableObject
{
    [SerializeField] private CookingRecipeSO _expectedCookingRecipeSO;
    [SerializeField] private Transform _placeForSpawnedObject;
    [SerializeField] private Transform _deliveredPackage;
    [SerializeField] private GoldCoins _goldCoins;

    private StateOfReadyness _readyness = StateOfReadyness.Cooked;
    private bool _packageDelivered;

    protected override void UseObject()
    {
        if (!_packageDelivered && Player.HasBackPack)
        {
            var deliveredDish = DeliveryService.CheckEquality(_expectedCookingRecipeSO);

            if (deliveredDish != null)
            {
                SpawnObject(_deliveredPackage);
                StartCoroutine(CheckReadynessOfDishe(deliveredDish));
                _packageDelivered = true;
            }
        }
    }

    private IEnumerator CheckReadynessOfDishe(CookingRecipeSO cookingRecipeSO)
    {
        yield return PayCountDownRoutine();

        if (cookingRecipeSO.Readyness == _readyness)
        {
            SpawnObject(_goldCoins);
        }
        else
        {
            TipsViewPanel.ShowDishIsPreparedBadlyTip();
        }

        DeliveryService.RemoveDeliveredDish(cookingRecipeSO);
    }

    private void SpawnObject(Object spawnedObject)
    {
        Instantiate(spawnedObject, _placeForSpawnedObject);
    }

    private IEnumerator PayCountDownRoutine()
    {
        int pause = 1;
        yield return new WaitForSeconds(pause);
        Destroy(_placeForSpawnedObject.GetChild(0).gameObject);
    }
}
