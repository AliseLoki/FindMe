using System.Collections;
using UnityEngine;

public class House : InteractableObject
{
    [SerializeField] private CookingRecipeSO _expectedCookingRecipeSO;
    [SerializeField] private Transform _placeForSpawnedObject;
    [SerializeField] private Transform _deliveredPackage;
    [SerializeField] private GoldCoins _goldCoins;

    private bool _isDelivered;

    private DeliveredDishesCounter _deliveredDishesCounter;

    private StateOfReadyness _readyness = StateOfReadyness.Cooked;

    public bool IsDelivered => _isDelivered;

    private void Start()
    {
        _deliveredDishesCounter = GameManager.Instance.GameEntryPoint.InitDeliveredDishesCounter();
    }

    protected override void UseObject()
    {
        int puttingSoundEffectIndex = 0;

        if (Player.HasBackPack)
        {
            var deliveredDish = DeliveryService.CheckEquality(_expectedCookingRecipeSO);

            if (deliveredDish != null)
            {
                PlaySoundEffect(AudioClipsList[puttingSoundEffectIndex]);
                SpawnObject(_deliveredPackage);
                StartCoroutine(CheckReadynessOfDishe(deliveredDish));
                _isDelivered = true;
            }
            else
            {
                TipsViewPanel.ShowIDidntOrderThisTip();
            }
        }
    }

    private IEnumerator CheckReadynessOfDishe(CookingRecipeSO cookingRecipeSO)
    {
        int goldAppearSoundEffectIndex = 1;

        yield return PayCountDownRoutine();

        if (cookingRecipeSO.Readyness == _readyness)
        {
            PlaySoundEffect(AudioClipsList[goldAppearSoundEffectIndex]);
            SpawnObject(_goldCoins);
            _deliveredDishesCounter.AddDeliveredDish();
            //добавить в счетчик доставленных блюд
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
