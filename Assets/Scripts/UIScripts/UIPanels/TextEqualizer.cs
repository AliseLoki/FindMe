using TMPro;
using UnityEngine;

namespace UIPanels
{
    public class TextEqualizer : MonoBehaviour
    {
        public void MakeAllTextSameSize(TMP_Text firstText, TMP_Text secondText)
        {
            if (firstText.fontSize > secondText.fontSize)
            {
                firstText.fontSize = secondText.fontSize;
            }
            else
            {
                secondText.fontSize = firstText.fontSize;
            }
        }
    }
}
