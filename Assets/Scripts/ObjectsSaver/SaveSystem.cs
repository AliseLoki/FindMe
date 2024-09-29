using System.Collections.Generic;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    [SerializeField] private Player _player;
   
    [SerializeField] private ObjectsSaver _objectSaver;

    private const string PlayerPrefsHasWood = nameof(PlayerPrefsHasWood);
    private const string PlayerPrefsHasWater = nameof(PlayerPrefsHasWater);
    private const string PlayerPrefsHasSeed = nameof(PlayerPrefsHasSeed);
    private const string PlayerPrefsHasSword = nameof(PlayerPrefsHasSword);

    private const string PlayerPrefsHasCow = nameof(PlayerPrefsHasCow);
    private const string PlayerPrefsHasTomatoForSeeds = nameof(PlayerPrefsHasTomatoForSeeds);
    private const string PlayerPrefsHasCabbageForSeeds = nameof(PlayerPrefsHasCabbageForSeeds);

    private const string PlayerPrefsHasBackPack = nameof(PlayerPrefsHasBackPack);

    [SerializeField] private Transform _tomatoPatchWithoutWater;
    [SerializeField] private Transform _cabbagePatchWithoutWater;
    [SerializeField] private Transform _cowPatchWithoutWater;


    private void OnEnable()
    {
      //  _player.PlayerEventsHandler.EnteredSafeZone += Save;

        //GetContainerState(PlayerPrefsGrassInCabbagePatch, 1, _cabbagePatchWithoutWater);
        //GetContainerState(PlayerPrefsGrassInTomatoPatch, 1, _tomatoPatchWithoutWater);
        //GetContainerState(PlayerPrefsCowInCowPlace, 1, _cowPatchWithoutWater);
    }

    private void OnDisable()
    {
       // _player.PlayerEventsHandler.EnteredSafeZone -= Save;
    }

    public bool LoadHasWood()
    {
        return ConvertIntToBool(PlayerPrefs.GetInt(PlayerPrefsHasWood, 0));
    }

    public bool LoadHasBackPack()
    {
        return ConvertIntToBool(PlayerPrefs.GetInt(PlayerPrefsHasBackPack, 0));
    }

    public bool LoadHasWater()
    {
        return ConvertIntToBool(PlayerPrefs.GetInt(PlayerPrefsHasWater, 0));
    }

    public bool LoadHasSeed()
    {
        return ConvertIntToBool(PlayerPrefs.GetInt(PlayerPrefsHasSeed, 0));
    }

    public bool LoadHasSword()
    {
        return ConvertIntToBool(PlayerPrefs.GetInt(PlayerPrefsHasSword, 0));
    }

    public bool LoadHasCow()
    {
        return ConvertIntToBool(PlayerPrefs.GetInt(PlayerPrefsHasCow, 0));
    }

    public bool LoadHasTomatoForSeeds()
    {
        return ConvertIntToBool(PlayerPrefs.GetInt(PlayerPrefsHasTomatoForSeeds, 0));
    }

    public bool LoadHasCabbageForSeeds()
    {
        return ConvertIntToBool(PlayerPrefs.GetInt(PlayerPrefsHasCabbageForSeeds, 0));
    }
  
    private void SaveState(string nameOfState, int value)
    {
        PlayerPrefs.SetInt(nameOfState, value);
    }

    private void Save()
    {
        //SaveState(PlayerPrefsHasWood, ConvertBoolToInt(_player.PlayerHands.HasWood));
        //SaveState(PlayerPrefsHasWater, ConvertBoolToInt(_player.PlayerHands.HasWater));
        //SaveState(PlayerPrefsHasSword, ConvertBoolToInt(_player.PlayerHands.HasSword));
        //SaveState(PlayerPrefsHasSeed, ConvertBoolToInt(_player.PlayerHands.HasSeed));

        //SaveState(PlayerPrefsHasCow, ConvertBoolToInt(_player.PlayerHands.HasCow));
        //SaveState(PlayerPrefsHasTomatoForSeeds, ConvertBoolToInt(_player.PlayerHands.HasTomatoForSeeds));
        //SaveState(PlayerPrefsHasCabbageForSeeds, ConvertBoolToInt(_player.PlayerHands.HasCabbageForSeeds));

        //// SaveState(PlayerPrefsHasBackPack, ConvertBoolToInt(_player.HasBackPack));

        //_objectSaver.SaveContainers();
    }

    private bool ConvertIntToBool(int value)
    {
        if (value == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private int ConvertBoolToInt(bool isActive)
    {
        if (isActive == true)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }
}
