using Cinemachine;
using UnityEngine;
using UnityEngine.UI;

public class Cameras : MonoBehaviour
{
    [SerializeField] private Slider _cameraSlider;
    [SerializeField] private Transform _outsideCamera;
    [SerializeField] private Transform _insideCamera;
    [SerializeField] private CinemachineVirtualCamera cinemachineVirtualCamera;

    [SerializeField] private Saver _saver;

    private void Awake()
    {
        _cameraSlider.value = _saver.LoadCameraValue();
        ChangeCameraZoom(_cameraSlider.value);
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

    //на слайдере камеры
    public void ZoomCamera()
    {
        ChangeCameraZoom(_cameraSlider.value);
        _saver.SaveCameraValue(_cameraSlider.value);
    }

    private void ChangeCameraZoom(float cameraSliderValue)
    {
        cinemachineVirtualCamera.m_Lens.FieldOfView = cameraSliderValue;
    }
}
