using System.Collections.Generic;
using UnityEngine;

public class ObjectsSaver : MonoBehaviour
{
    private const string PlayerPrefsMeetContainerState = nameof(PlayerPrefsMeetContainerState);
    private const string PlayerPrefsCheeseContainerState = nameof(PlayerPrefsCheeseContainerState);
    private const string PlayerPrefsCabbageContainerState = nameof(PlayerPrefsCabbageContainerState);
    private const string PlayerPrefsTomatoContainerState = nameof(PlayerPrefsTomatoContainerState);

    private const string PlayerPrefsGrassInTomatoPatch = nameof(PlayerPrefsGrassInTomatoPatch);
    private const string PlayerPrefsGrassInCabbagePatch = nameof(PlayerPrefsGrassInCabbagePatch);
    private const string PlayerPrefsCowInCowPlace = nameof(PlayerPrefsCowInCowPlace);

    [SerializeField] private Transform _tomatoPatchWithoutWater;
    [SerializeField] private Transform _cabbagePatchWithoutWater;
    [SerializeField] private Transform _cowPatchWithoutWater;

    [SerializeField] private Transform _meetHanger;
    [SerializeField] private Transform _bowlWithCheese;
    [SerializeField] private Transform _basketWithCabbages;
    [SerializeField] private Transform _barrelWithTomatoes;

    [SerializeField] private List<Transform> _tomatoPatch;
    [SerializeField] private List<Transform> _cabbagePatch;
    [SerializeField] private List<Transform> _cowPatch;

    [SerializeField] private GameStatesSwitcher _gameStatesSwitcher;

    private void Start()
    {
        if (!_gameStatesSwitcher.IsFirstStart)
        {
            GetContainerState(PlayerPrefsMeetContainerState, 1, _meetHanger);
            GetContainerState(PlayerPrefsCheeseContainerState, 1, _bowlWithCheese);
            GetContainerState(PlayerPrefsCabbageContainerState, 1, _basketWithCabbages);
            GetContainerState(PlayerPrefsTomatoContainerState, 1, _barrelWithTomatoes);

            ActivatePatch(_bowlWithCheese, _cowPatch);
            ActivatePatch(_basketWithCabbages, _cabbagePatch);
            ActivatePatch(_barrelWithTomatoes, _tomatoPatch);

            GetContainerState(PlayerPrefsGrassInCabbagePatch, 1, _cabbagePatchWithoutWater);
            GetContainerState(PlayerPrefsGrassInTomatoPatch, 1, _tomatoPatchWithoutWater);
            GetContainerState(PlayerPrefsCowInCowPlace, 1, _cowPatchWithoutWater);
        }
        else
        {
            Reset();
        }
    }

    public void SaveContainers()
    {
        Save(_meetHanger, PlayerPrefsMeetContainerState);
        Save(_bowlWithCheese, PlayerPrefsCheeseContainerState);
        Save(_basketWithCabbages, PlayerPrefsCabbageContainerState);
        Save(_barrelWithTomatoes, PlayerPrefsTomatoContainerState);

        Save(_cabbagePatchWithoutWater, PlayerPrefsGrassInCabbagePatch);
        Save(_tomatoPatchWithoutWater, PlayerPrefsGrassInTomatoPatch);
        Save(_cowPatchWithoutWater, PlayerPrefsCowInCowPlace);
    }

    private void Reset()
    {
        _meetHanger.gameObject.SetActive(false);
        _bowlWithCheese.gameObject.SetActive(false);
        _basketWithCabbages.gameObject.SetActive(false);
        _barrelWithTomatoes.gameObject.SetActive(false);

        CheckAllTransforms(_cowPatch, false);
        CheckAllTransforms(_cabbagePatch, false);
        CheckAllTransforms(_tomatoPatch, false);
    }

    private void CheckAllTransforms(List<Transform> transformList, bool isActive)
    {
        foreach (var transform in transformList)
        {
            transform.gameObject.SetActive(isActive);
        }
    }  

    private void ActivatePatch(Transform container, List<Transform> transformList)
    {
        if (container.gameObject.activeSelf)
        {
            CheckAllTransforms(transformList, true);
        }
        else
        {
            CheckAllTransforms(transformList, false);
        }
    }

    private void Save(Transform container, string containerState)
    {
        if (container.gameObject.activeSelf)
        {
            SetContainerState(containerState, true);
        }
        else
        {
            SetContainerState(containerState, false);
        }
    }

    private void GetContainerState(string containerState, int defaultValue, Transform container)
    {
        int savedValue = PlayerPrefs.GetInt(containerState, defaultValue);
        bool isActive = ConvertIntToBool(savedValue);
        container.gameObject.SetActive(isActive);
    }

    private void SetContainerState(string containerState, bool isActive)
    {
        PlayerPrefs.SetInt(containerState, ConvertBoolToInt(isActive)); 
        // в документации
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
