using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Sign : MonoBehaviour
{
    [SerializeField] private List<TMP_Text> _texts;

    public void InitPointerNames(List<string> names)
    {
        for (int i = 0; i < _texts.Count;)
        {
            for (int j = 0; j < names.Count;)
            {
                _texts[i].text = names[j];
                i++; 
                j++;
            }
        }
    }
}
