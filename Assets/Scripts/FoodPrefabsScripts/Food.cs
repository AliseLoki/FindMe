using UnityEngine;

public class Food : MonoBehaviour
{
    public void SetInParent(Transform parent)
    {
        this.transform.parent = parent;
        this.transform.position = parent.transform.position;
    }

}
