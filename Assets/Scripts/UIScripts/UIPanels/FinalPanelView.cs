using TMPro;
using UnityEngine;

namespace UIPanels
{
    public class FinalPanelView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _looseText;
        [SerializeField] private TMP_Text _winText;

        private void OnEnable()
        {
            _looseText.gameObject.SetActive(false);
        }
    }
}
