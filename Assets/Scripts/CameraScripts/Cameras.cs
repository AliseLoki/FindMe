using UnityEngine;

public class Cameras : MonoBehaviour
{
    [SerializeField] private Transform _outsideCamera;
    [SerializeField] private Transform _insideCamera;

    public void SwitchCameras()
    {
        if (_outsideCamera.gameObject.activeInHierarchy)
        {
            _outsideCamera.gameObject.SetActive(false);
            _insideCamera.gameObject.SetActive(true);
        }
        else
        {
            _outsideCamera.gameObject.SetActive(true);
            _insideCamera.gameObject.SetActive(false);
        }
    }
}
