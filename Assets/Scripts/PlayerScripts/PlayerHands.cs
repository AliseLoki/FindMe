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
   
    private bool _hasSeed;
    //private bool _hasSword;
    private bool _hasCow;
    private bool _hasCabbageForSeeds;
    private bool _hasTomatoForSeeds;
    private bool _hasNecronomicon;

    public InventoryPrefabSO InventoryPrefabSO => _inventoryPrefabSO;

    public bool HasSomethingInHands => _objectInHands != null;//_hasSomethingInHands;

    public bool HasBackPack => _hasBackPack;

    public bool HasSeed => _hasSeed;

    //public bool HasSword => _hasSword;

    public bool HasCow => _hasCow;

    public bool HasCabbageForSeeds => _hasCabbageForSeeds;

    public bool HasTomatoForSeeds => _hasTomatoForSeeds;

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


    //при нажатии на €чейку инвентар€

    public void TakeSwordInHands(InventoryPrefabSO inventoryPrefabSO)
    {
        TakeInvenoryPrefabInHands(inventoryPrefabSO);
        _tipsViewPanel.ShowYouCankillTheWolfNowTip();
    }

    public void TakeObject(GameObject gameObject, HoldableObjects holdableObjects)
    {
        _objectInHands = gameObject;
        _indexOfObjectInHands = holdableObjects;       
        _objectInHands.transform.parent = _handlePoint.transform;
        _objectInHands.transform.position = _handlePoint.position;
    }

    public void GiveObject()
    {
        _objectInHands = null;
        _indexOfObjectInHands = 0;
        Destroy(_handlePoint.GetChild(0).gameObject);
    }

    private void Reset()
    {
        _hasBackPack = false;

        _objectInHands = null;
        _indexOfObjectInHands = 0;

        _hasSeed = false;
      
        _hasCow = false;
        _hasCabbageForSeeds = false;
        _hasTomatoForSeeds = false;
        _hasNecronomicon = false;
    }


    private void InitAllBooleans()
    {
        _hasBackPack = _saver.LoadHasBackPack();
        _indexOfObjectInHands = _saver.LoadObjectInHands();
        
        //    _hasSeed = _saver.LoadHasSeed();
        //    _hasCow = _saver.LoadHasCow();
        //    _hasTomatoForSeeds = _saver.LoadHasTomatoForSeeds();
        //    _hasCabbageForSeeds = _saver.LoadHasCabbageForSeeds();
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
           // _inventoryPrefabSO = _spawner.SpawnSwordInHandsss();
        }
        else if (_hasCow == true)
        {
            //_inventoryPrefabSO = _spawner.SpawnCowInHands();
        }
        else if (_hasTomatoForSeeds == true)
        {
            //_inventoryPrefabSO = _spawner.SpawnTomatoForSeedsInHands();
        }
        else if (_hasCabbageForSeeds == true)
        {
           // _inventoryPrefabSO = _spawner.SpawnCabbageForSeedsInHands();
        }
        else if (_hasNecronomicon == true)
        {
            //_inventoryPrefabSO = _spawner.SpawnNecronomicon();
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
        _hasSeed = true;
        _tipsViewPanel.ShowBringmeToPatchTip();
    }


    public void TakeNecronomiconInHands(InventoryPrefabSO inventoryPrefabSO)
    {
        TakeInvenoryPrefabInHands(inventoryPrefabSO);
        _hasNecronomicon = true;
    }

    public void LandSeed()
    {
        CheckWitchSeed(_inventoryPrefabSO, false);
        Destroy(_handlePoint.GetChild(0).gameObject);
        _hasSeed = false;
        _inventoryPrefabSO = null;
    }

    private void TakeInvenoryPrefabInHands(InventoryPrefabSO inventoryPrefabSO)
    {
        //дл€ коровы и сем€н, надо от него избавитьс€
        CheckWitchSeed(inventoryPrefabSO, true);

        //вот это тэйк
        var prefabInHands = Instantiate(inventoryPrefabSO.InventoryPrefab, _handlePoint, true);
        prefabInHands.transform.position = _handlePoint.position;
        prefabInHands.GetComponent<Collider>().enabled = false;

        //спаун
        //отключение коллайдера 
        // перемещение позиции

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

    private void CheckWitchSeed(InventoryPrefabSO inventoryPrefabSO, bool isTrue)
    {
        if (inventoryPrefabSO.InventoryPrefab as Cow)
        {
            _hasCow = isTrue;
        }
        else if (inventoryPrefabSO.InventoryPrefab as CabbageForSeeds)
        {
            _hasCabbageForSeeds = isTrue;
        }
        else if (inventoryPrefabSO.InventoryPrefab as TomatoForSeeds)
        {
            _hasTomatoForSeeds = isTrue;
        }
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
