using Cinemachine;
using UnityEngine;
using UnityEngine.UI;

public class Cameras : MonoBehaviour
{
    private const string CameraZoomValue = nameof(CameraZoomValue);

    [SerializeField] private Slider _cameraSlider;
    [SerializeField] private Transform _outsideCamera;
    [SerializeField] private Transform _insideCamera;
    [SerializeField] private CinemachineVirtualCamera cinemachineVirtualCamera;

    private void Awake()
    {
        _cameraSlider.value = PlayerPrefs.GetFloat(CameraZoomValue, 30f);
        ChangeCameraZoom();
    }

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
        ChangeCameraZoom();
        PlayerPrefs.SetFloat(CameraZoomValue, _cameraSlider.value);
        PlayerPrefs.Save();
    }

    private void ChangeCameraZoom()
    {
        cinemachineVirtualCamera.m_Lens.FieldOfView = _cameraSlider.value;
    }
}
