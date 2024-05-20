using TMPro;
using UnityEngine;

public class InternationalText : MonoBehaviour
{
    [SerializeField] private string _en;
    [SerializeField] private string _ru;

    private void Start()
    {
        if (Language.Instance.CurrentLanguage == "en")
        {
            GetComponent<TMP_Text>().text = _en;
        }
        else if (Language.Instance.CurrentLanguage == "ru")
        {
            GetComponent<TMP_Text>().text = _ru;
        }
        else
        {
            GetComponent<TMP_Text>().text = _en;
        }
    }
}
