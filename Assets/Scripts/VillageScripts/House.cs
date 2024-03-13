using System.Collections;
using System.Net;
using UnityEngine;

public class House : InteractableObject
{
    //����� ������������� ��������
    //����� �� ��������� ��������� ����� ��� ������ ��������
    // ��� ����� ������� ������������ ��������� ����� �� ����������� �� ����� � �����
    // ��� ������� ���, ����� �������� �� ���������

    [SerializeField] private CookingRecipeSO _waitedDish;
    [SerializeField] private StateOfReadyness _readyness;
    [SerializeField] private Transform _placeForSpawnedObject;
    [SerializeField] private Transform _deliveredPackage;
    [SerializeField] private GoldCoins _goldCoins;

    private bool _packageDelivered;
    private Coroutine _waitingCoroutine;

    protected override void UseObject()
    {
        if (!_packageDelivered && Player.Instance.HasBackPack)
        {
            var deliveredDish = Player.Instance.DeliverFood(_waitedDish);

            if (deliveredDish != null)
            {
                SpawnObject(_deliveredPackage);
                CheckReadynessOfDishe(deliveredDish);
                _packageDelivered = true;
            }
        }
    }

    private void CheckReadynessOfDishe(CookingRecipeSO cookingRecipeSO)
    {
        _waitingCoroutine = StartCoroutine(PayCountDownRoutine());

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
        int pause = 4;
        yield return new WaitForSeconds(pause);
        print("coroutine works");
        Destroy(_placeForSpawnedObject.GetChild(0).gameObject);
        _waitingCoroutine = null;
    }
}
