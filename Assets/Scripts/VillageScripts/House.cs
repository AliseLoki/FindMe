using System.Collections;
using System.Net;
using Unity.Android.Types;
using UnityEngine;

public class House : InteractableObject
{
    // ��� ����� ������� ������������ ��������� ����� �� ����������� �� ����� � ����� 
    // ��� ������� ���, ����� �������� �� ���������

    [SerializeField] private CookingRecipeSO _waitedDish;
    [SerializeField] private StateOfReadyness _readyness;
    [SerializeField] private Transform _placeForSpawnedObject;
    [SerializeField] private Transform _deliveredPackage;
    [SerializeField] private GoldCoins _goldCoins;

    private bool _packageDelivered;
    
    protected override void UseObject()
    {

       // PlayerPrefs
        if (!_packageDelivered && Player.Instance.HasBackPack)
        {
            var deliveredDish = Player.Instance.DeliverFood(_waitedDish);

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
            PayMoney();
            SpawnObject(_goldCoins);
        }
        else
        {
            print("����� �� ������������� ������");
        }
    }

    private void SpawnObject(Object spawnedObject)
    {
        Instantiate(spawnedObject, _placeForSpawnedObject);
    }

    private void PayMoney()
    {
        // ��������� ������� ������, ��� ������������ ���������� ������ � �������� ������ ���������� �������
        // ������� ����������� ����� �������������� � 2� �������� ������ � ������ ���
    }

    private IEnumerator PayCountDownRoutine()
    {
        int pause = 2;
        yield return new WaitForSeconds(pause);
        Destroy(_placeForSpawnedObject.GetChild(0).gameObject);
    }
}
