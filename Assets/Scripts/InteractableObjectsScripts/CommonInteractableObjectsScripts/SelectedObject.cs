using UnityEngine;

public class SelectedObject : MonoBehaviour
{
    public void Show()
    {
        this.gameObject.SetActive(true);
    }

    public void Hide()
    {
        this .gameObject.SetActive(false);
    }
}