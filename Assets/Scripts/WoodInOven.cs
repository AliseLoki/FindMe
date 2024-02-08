using UnityEngine;

public class WoodInOven : MonoBehaviour
{
    private bool _hasWood;

    public void PutWood()
    {
        if (_hasWood)
        {
            return;
        }
        else
        {
            this.gameObject.SetActive(true);
        }
    }

    public void TakeWood()
    {
        this.gameObject.SetActive(false);
    }
}
