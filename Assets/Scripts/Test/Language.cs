using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Language : MonoBehaviour
{
    public static Language Instance;

    //внешний метод для подключения через сдк GetLang();

    public string CurrentLanguage = "en";

    [SerializeField] private TMP_Text _languageText;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            //CurrentLanguage = GetLang();
            _languageText.text = CurrentLanguage;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
