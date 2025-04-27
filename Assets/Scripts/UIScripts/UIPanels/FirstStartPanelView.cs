using SO;
using TMPro;
using UnityEngine;

namespace UIPanels
{
    public class FirstStartPanelView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;
       
        private FirstStartTextSO _firstStartTextSO;

        public void InitFirstStartTextSO(FirstStartTextSO firstStartTextSO)
        {
            _firstStartTextSO = firstStartTextSO;
            Show();
        }

        private void Show()
        {
            PrintText(_firstStartTextSO.RunText);
        }

        private void PrintText(string text)
        {
            _text.text = text;
        }
    }
}
