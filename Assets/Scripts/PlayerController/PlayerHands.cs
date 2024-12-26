using DeliveryServiceHandler;
using Indexes;
using Interactables.InventoryPrefabs;
using SaveSystem;
using SO;
using UnityEngine;

namespace PlayerController
{
    [RequireComponent(typeof(Player))]
    public class PlayerHands : MonoBehaviour
    {
        [SerializeField] private Transform _backpack;
        [SerializeField] private Transform _handlePoint;

        [SerializeField] private Spawner _spawner;
        [SerializeField] private DeliveryService _deliveryService;

        private bool _hasBackPack;

        private InventoryPrefabSO _inventoryPrefabSO;
        private HoldableObjectType _indexOfObjectInHands;
        private GameObject _objectInHands;

        public InventoryPrefabSO InventoryPrefabSO => _inventoryPrefabSO;

        public bool HasSomethingInHands => _objectInHands != null;

        public bool HasBackPack => _hasBackPack;

        public GameObject ObjectInHands => _objectInHands;

        public HoldableObjectType HoldableObject => _indexOfObjectInHands;

        public Transform HandlePoint => _handlePoint;

        private void OnEnable()
        {
            _deliveryService.AllDishesHaveBeenDelivered += OnAllDishesHaveBeenDelivered;
        }

        private void OnDisable()
        {
            _deliveryService.AllDishesHaveBeenDelivered -= OnAllDishesHaveBeenDelivered;
        }

        public void InitHoldableObjectType(HoldableObjectType holdableObjectType)
        {
            _indexOfObjectInHands = holdableObjectType;
            _spawner.SpawnHoldableObjectInHands(_indexOfObjectInHands);
        }

        public void InitHasBackPack(bool hasBackPack)
        {
            _hasBackPack = hasBackPack;
            ShowOrHideBackPack(_hasBackPack);
        }

        public void GiveObject()
        {
            _objectInHands = null;
            _indexOfObjectInHands = 0;
            _inventoryPrefabSO = null;

            if (_handlePoint.childCount > 0)
            {
                Destroy(_handlePoint.GetChild(0).gameObject);
            }
        }

        public void TakeObject(GameObject gameObject, HoldableObjectType holdableObjects)
        {
            _objectInHands = gameObject;
            _indexOfObjectInHands = holdableObjects;

            if (gameObject.TryGetComponent(out InventoryPrefab inventoryPrefab))
            {
                _inventoryPrefabSO = inventoryPrefab.ConnectedInentoryPrefabSO;
            }

            _objectInHands.transform.parent = _handlePoint.transform;
            _objectInHands.transform.position = _handlePoint.position;
        }

        public void TakeInvenoryPrefabInHands(InventoryPrefabSO inventoryPrefabSO)
        {
            var prefabInHands = Instantiate(inventoryPrefabSO.InventoryPrefab);
            TakeObject(prefabInHands.gameObject, prefabInHands.HoldableObjects);
            prefabInHands.DisableCollider();

            if (inventoryPrefabSO.InventoryPrefab as Cow)
            {
                prefabInHands.transform.rotation = Quaternion.LookRotation(transform.right);
            }
            else
            {
                prefabInHands.transform.rotation = Quaternion.LookRotation(transform.forward);
            }
        }

        private void OnAllDishesHaveBeenDelivered()
        {
            ShowOrHideBackPack(false);
        }

        public void ShowOrHideBackPack(bool isActive)
        {
            _backpack.gameObject.SetActive(isActive);
            _hasBackPack = isActive;
        }

        private void Reset()
        {
            _hasBackPack = false;
            _objectInHands = null;
            _indexOfObjectInHands = 0;
        }
    }
}
