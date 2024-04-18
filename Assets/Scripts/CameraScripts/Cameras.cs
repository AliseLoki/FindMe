using Cinemachine;
using UnityEngine;
using UnityEngine.UI;

public class Cameras : MonoBehaviour
{
    [SerializeField] private Slider _cameraSlider;
    [SerializeField] private Transform _outsideCamera;
    [SerializeField] private Transform _insideCamera;
    [SerializeField] private CinemachineVirtualCamera cinemachineVirtualCamera;

   
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

    public void ZoomCamera()
    {
        cinemachineVirtualCamera.m_Lens.FieldOfView = _cameraSlider.value;
    }
}
