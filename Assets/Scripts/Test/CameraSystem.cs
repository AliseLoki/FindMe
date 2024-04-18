using Cinemachine;
using UnityEngine;

public class CameraSystem : MonoBehaviour
{
    [SerializeField] private bool _isEnableEdgeScrolling;
    [SerializeField] private bool _canDragPanMove;
    [SerializeField] private CinemachineVirtualCamera _cinemachineVirtualCamera;

    private float _fieldOfViewMax = 50;
    private float _fieldOfViewMin = 10;
    private float _targetFieldOfView = 50f;
    private Vector2 _lastMousePosition;

    private void Update()
    {
        HandleCameraMovement();

        if (_isEnableEdgeScrolling)
        {
            HandleCameraMovementEdgeScrolling();
        }

        if (_canDragPanMove)
        {
            HandleCameraMovementDragPan();
        }

        HandleCameraRotation();
        HandleCameraZoom();
    }

    private void HandleCameraMovement()
    {
        Vector3 inputDir = new Vector3(0, 0, 0);

        if (Input.GetKey(KeyCode.W)) inputDir.z = 1f;
        if (Input.GetKey(KeyCode.S)) inputDir.z = -1f;
        if (Input.GetKey(KeyCode.A)) inputDir.x = -1f;
        if (Input.GetKey(KeyCode.D)) inputDir.x = 1f;

        Vector3 moveDir = transform.forward * inputDir.z + transform.right * inputDir.x;
        float moveSpeed = 50f;
        transform.position += moveDir * moveSpeed * Time.deltaTime;
    }

    private void HandleCameraMovementEdgeScrolling()
    {
        Vector3 inputDir = new Vector3(0, 0, 0);

        int edgeScrollSize = 20;

        if (Input.mousePosition.x < edgeScrollSize)
            inputDir.x = -1;

        if (Input.mousePosition.y < edgeScrollSize)
            inputDir.z = -1;

        if (Input.mousePosition.x > Screen.width - edgeScrollSize)
            inputDir.x = 1;

        if (Input.mousePosition.y > Screen.height - edgeScrollSize)
            inputDir.z = 1;

        Vector3 moveDir = transform.forward * inputDir.z + transform.right * inputDir.x;
        float moveSpeed = 50f;
        transform.position += moveDir * moveSpeed * Time.deltaTime;
    }

    private void HandleCameraMovementDragPan()
    {
        Vector3 inputDir = new Vector3(0, 0, 0);

        if (Input.GetMouseButtonDown(1))
        {
            _canDragPanMove = true;
            _lastMousePosition = Input.mousePosition;
        }


        if (Input.GetMouseButtonUp(1))
        {
            _canDragPanMove = false;
        }

        if (_canDragPanMove)
        {
            Vector2 mouseMovementDelta = (Vector2)Input.mousePosition - _lastMousePosition;

            float dragPanSpeed = 2f;

            inputDir.x = mouseMovementDelta.x * dragPanSpeed;
            inputDir.z = mouseMovementDelta.y * dragPanSpeed;

            _lastMousePosition = Input.mousePosition;
        }

        Vector3 moveDir = transform.forward * inputDir.z + transform.right * inputDir.x;
        float moveSpeed = 50f;
        transform.position += moveDir * moveSpeed * Time.deltaTime;
    }

    private void HandleCameraRotation()
    {
        float rotateDir = 0f;
        float rotateSpeed = 100f;

        if (Input.GetKey(KeyCode.Q)) rotateDir = +1f;
        if (Input.GetKey(KeyCode.E)) rotateDir = -1f;

        transform.eulerAngles += new Vector3(0, rotateDir * rotateSpeed * Time.deltaTime, 0);
    }

    private void HandleCameraZoom()
    {
        if (Input.mouseScrollDelta.y > 0)
        {
            _targetFieldOfView += 5;
        }

        if (Input.mouseScrollDelta.y < 0)
        {
            _targetFieldOfView -= 5;
        }

        _targetFieldOfView = Mathf.Clamp(_targetFieldOfView, _fieldOfViewMin, _fieldOfViewMax);

        float zoomSpeed = 10f;

        _cinemachineVirtualCamera.m_Lens.FieldOfView =
            Mathf.Lerp(_cinemachineVirtualCamera.m_Lens.FieldOfView, _targetFieldOfView, Time.deltaTime * zoomSpeed);
    }
}
