using Agava.YandexGames;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(TextEqualizer))]
public class AuthorisePanel : MonoBehaviour
{
    [SerializeField] private TMP_Text _authorizeButtonText;
    [SerializeField] private TMP_Text _closeButtonText;
    [SerializeField] private TMP_Text _needToAuthorizeText;

    private TextEqualizer _textEqualizer;
    private FirstStartTextSO _firstStartTextSO;

    private void Awake()
    {
        _textEqualizer = GetComponent<TextEqualizer>();
    }

    private void Start()
    {
        InitButtonsText();
        _textEqualizer.MakeAllTextSameSize(_authorizeButtonText, _closeButtonText);
    }

    public void InitFirstStartTextSO(FirstStartTextSO firstStarttextSO)
    {
        _firstStartTextSO = firstStarttextSO;
    }

    public void OnAuthorizeButtonPressed()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        
        PlayerAccount.Authorize();
#endif
        this.gameObject.SetActive(false);
    }

    private void InitButtonsText()
    {
        _authorizeButtonText.text = _firstStartTextSO.AuthorizeButtonText;
        _closeButtonText.text = _firstStartTextSO.CloseButtonText;
        _needToAuthorizeText.text = _firstStartTextSO.NeedToAuthorizeText;
    }
}