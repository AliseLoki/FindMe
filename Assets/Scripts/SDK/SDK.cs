using Agava.YandexGames;
using UnityEngine;

public class SDK : MonoBehaviour
{
    private void Start()
    {
#if UNITY_WEBGL && !UNITY_EDITOR

        OnCallGameReadyButtonClick();
#endif
    }

    public void OnCallGameReadyButtonClick()
    {
        YandexGamesSdk.GameReady();
    }
}
