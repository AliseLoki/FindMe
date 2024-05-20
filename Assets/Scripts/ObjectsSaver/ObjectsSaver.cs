using System.Collections.Generic;
using UnityEngine;

public class ObjectsSaver : MonoBehaviour
{
    private const string PlayerPrefsMeetContainerState = nameof(PlayerPrefsMeetContainerState);
    private const string PlayerPrefsCheeseContainerState = nameof(PlayerPrefsCheeseContainerState);
    private const string PlayerPrefsCabbageContainerState = nameof(PlayerPrefsCabbageContainerState);
    private const string PlayerPrefsTomatoContainerState = nameof(PlayerPrefsTomatoContainerState);

    [SerializeField] private InteractableObject _meetHanger;
    [SerializeField] private InteractableObject _bowlWithCheese;
    [SerializeField] private InteractableObject _basketWithCabbages;
    [SerializeField] private InteractableObject _barrelWithTomatoes;

    [SerializeField] private List<Transform> _tomatoPatch;
    [SerializeField] private List<Transform> _cabbagePatch;
    [SerializeField] private List<Transform> _cowPatch;

    private void Start()
    {
        if (!GameManager.Instance.IsFirstStart)
        {
            GetContainerState(PlayerPrefsMeetContainerState, 1, _meetHanger);
            GetContainerState(PlayerPrefsCheeseContainerState, 1, _bowlWithCheese);
            GetContainerState(PlayerPrefsCabbageContainerState, 1, _basketWithCabbages);
            GetContainerState(PlayerPrefsTomatoContainerState, 1, _barrelWithTomatoes);

            ActivatePatch(_bowlWithCheese, _cowPatch);
            ActivatePatch(_basketWithCabbages, _cabbagePatch);
            ActivatePatch(_barrelWithTomatoes, _tomatoPatch);
        }
        else
        {
            Reset();
        }
    }

    private void Update()
    {
        Save(_meetHanger, PlayerPrefsMeetContainerState);
        Save(_bowlWithCheese, PlayerPrefsCheeseContainerState);
        Save(_basketWithCabbages, PlayerPrefsCabbageContainerState);
        Save(_barrelWithTomatoes, PlayerPrefsTomatoContainerState);
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

    private void ActivatePatch(InteractableObject container, List<Transform> transformList)
    {
        if (container.isActiveAndEnabled)
        {
            CheckAllTransforms(transformList, true);
        }
        else
        {
            CheckAllTransforms(transformList,false);
        }
    }

    private void Save(InteractableObject container, string containerState)
    {
        if (container.isActiveAndEnabled)
        {
            SetContainerState(containerState, true);
        }
        else
        {
            SetContainerState(containerState, false);
        }
    }

    private void GetContainerState(string containerState, int defaultValue, InteractableObject container)
    {
        int savedValue = PlayerPrefs.GetInt(containerState, defaultValue);
        bool isActive = ConvertIntToBool(savedValue);
        container.gameObject.SetActive(isActive);
    }

    private void SetContainerState(string containerState, bool isActive)
    {
        PlayerPrefs.SetInt(containerState, ConvertBoolToInt(isActive));
        PlayerPrefs.Save();
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
