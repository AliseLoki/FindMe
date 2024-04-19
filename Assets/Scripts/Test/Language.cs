using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;

public class Language : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern string GetLang();

    public static Language Instance;

    public string CurrentLanguage;

    [SerializeField] TMP_Text _languageText;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            CurrentLanguage = GetLang();
            _languageText.text = CurrentLanguage;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
