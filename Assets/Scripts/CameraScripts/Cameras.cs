using Cinemachine;
using SaveSystem;
using UnityEngine;
using UnityEngine.UI;

public class Cameras : MonoBehaviour
{
    [SerializeField] private Slider _cameraSlider;
    [SerializeField] private Transform _outsideCamera;
    [SerializeField] private Transform _insideCamera;
    [SerializeField] private CinemachineVirtualCamera _cinemachineVirtualCamera;
    [SerializeField] private Saver _saver;

    private float _minValue = 20f;
    private float _maxValue = 70f;

    //private void Awake()
    //{
    //    _cameraSlider.value = _saver.LoadCameraValue();
    //    ChangeCameraZoom(_cameraSlider.value);
    //}

    private void Update()
    {
        ZoomCameraWithMouseWheel();
    }

    public void Init(Transform target)
    {
        _cinemachineVirtualCamera.Follow = target;
        _cinemachineVirtualCamera.LookAt = target;

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

    public void ZoomCamera()
    {
        ChangeCameraZoom(_cameraSlider.value);
        _saver.SaveCameraValue(_cameraSlider.value);
    }

    private void ChangeCameraZoom(float cameraSliderValue)
    {
        _cinemachineVirtualCamera.m_Lens.FieldOfView = cameraSliderValue;
    }

    private void ZoomCameraWithMouseWheel()
    {
        _cinemachineVirtualCamera.m_Lens.FieldOfView = Mathf.Clamp(_cinemachineVirtualCamera.m_Lens.FieldOfView - Input.mouseScrollDelta.y, _minValue, _maxValue);
        _saver.SaveCameraValue(_cameraSlider.value);
    }
}
