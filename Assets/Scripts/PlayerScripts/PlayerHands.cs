using UnityEngine;

public class PlayerHands : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Transform _backpack;
    [SerializeField] private Transform _handlePoint;

    [SerializeField] private Spawner _spawner;
    [SerializeField] private TipsViewPanel _tipsViewPanel;
    [SerializeField] private Saver _saver;

    private InventoryPrefabSO _inventoryPrefabSO;

    private HoldableObjects _indexOfObjectInHands;
    private GameObject _objectInHands;

    //private bool _hasSomethingInHands;
    private bool _hasBackPack;

   // private bool _hasCabbageForSeeds;
    private bool _hasCow;
    private bool _hasNecronomicon;

    public InventoryPrefabSO InventoryPrefabSO => _inventoryPrefabSO;

    public bool HasSomethingInHands => _objectInHands != null;//_hasSomethingInHands;

    public bool HasBackPack => _hasBackPack;

    public bool HasCow => _hasCow;

   // public bool HasCabbageForSeeds => _hasCabbageForSeeds;

    public bool HasNecronomicon => _hasNecronomicon;

    public GameObject ObjectInHands => _objectInHands;

    public HoldableObjects HoldableObject => _indexOfObjectInHands;

    public Transform HandlePoint => _handlePoint;


    private void Start()
    {
        InitAllBooleans();
        Load();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Reset();
        }
    }

    //при нажатии на ячейку инвентаря

    public void TakeSwordInHands(InventoryPrefabSO inventoryPrefabSO)
    {
        TakeInvenoryPrefabInHands(inventoryPrefabSO);
        _tipsViewPanel.ShowYouCankillTheWolfNowTip();
    }

    public void TakeObject(GameObject gameObject, HoldableObjects holdableObjects)
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

    public void GiveObject()
    {
        _objectInHands = null;
        _indexOfObjectInHands = 0;
        _inventoryPrefabSO = null;
        Destroy(_handlePoint.GetChild(0).gameObject);
    }

    private void Reset()
    {
        _hasBackPack = false;

        _objectInHands = null;
        _indexOfObjectInHands = 0;

        _hasCow = false;
        _hasNecronomicon = false;
    }


    private void InitAllBooleans()
    {
        _hasBackPack = _saver.LoadHasBackPack();
        _indexOfObjectInHands = _saver.LoadObjectInHands();

        //    _hasCow = _saver.LoadHasCow();
        //    _hasNecronomicon = _saver.LoadHasNecronomicon();
    }

    private void Load()
    {
        if (_hasBackPack == true)
        {
            ShowOrHideBackPack(true);
        }

        if (_indexOfObjectInHands == HoldableObjects.Wood)
        {
            _spawner.SpawnWoodInHands();
        }
        else if (_indexOfObjectInHands == HoldableObjects.Water)
        {
            _spawner.SpawnBucketOfWaterInHands();
        }
        else if (_indexOfObjectInHands == HoldableObjects.Sword)
        {
            _spawner.SpawnSwordInHands();
        }
        else if (_indexOfObjectInHands == HoldableObjects.TomatoForSeeds)
        {
            _spawner.SpawnTomatoForSeedsInHands();
        }
        else if (_indexOfObjectInHands == HoldableObjects.CabbageForSeeds)
        {
            _spawner.SpawnCabbageForSeedsInHands();
        }
        else if (_hasCow == true)
        {
            _inventoryPrefabSO = _spawner.SpawnCowInHands();
        }
        else if (_hasNecronomicon == true)
        {
            _inventoryPrefabSO = _spawner.SpawnNecronomicon();
        }
    }

    public void ShowOrHideBackPack(bool isActive)
    {
        _backpack.gameObject.SetActive(isActive);
        _hasBackPack = isActive;
    }

    public void TakeSeedInHands(InventoryPrefabSO inventoryPrefabSO)
    {
        TakeInvenoryPrefabInHands(inventoryPrefabSO);
        _tipsViewPanel.ShowBringmeToPatchTip();
    }


    public void TakeNecronomiconInHands(InventoryPrefabSO inventoryPrefabSO)
    {
        TakeInvenoryPrefabInHands(inventoryPrefabSO);
        _hasNecronomicon = true;
    }

    private void TakeInvenoryPrefabInHands(InventoryPrefabSO inventoryPrefabSO)
    {
        //вот это тэйк
        var prefabInHands = Instantiate(inventoryPrefabSO.InventoryPrefab);
        TakeObject(prefabInHands.gameObject, prefabInHands.HoldableObjects);

        if (!CheckIfCow(inventoryPrefabSO))
        {
            prefabInHands.transform.rotation = Quaternion.LookRotation(transform.forward);
        }
        else
        {
            prefabInHands.transform.rotation = Quaternion.LookRotation(transform.right);
        }

        _inventoryPrefabSO = inventoryPrefabSO;
    }

    private bool CheckIfCow(InventoryPrefabSO inventoryPrefabSO)
    {
        if ((inventoryPrefabSO.InventoryPrefab as Cow))
        {
            return true;
        }

        return false;
    }
}
