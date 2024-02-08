using UnityEngine;

public class WaterInPan : MonoBehaviour
{
    private bool _hasWater;

    public void PutWater()
    {
        if (_hasWater)
        {
            return;
        }
        else
        {
            this.gameObject.SetActive(true);
        }
    }

    public void TakeWater()
    {
        this.gameObject.SetActive(false);
    }
}
