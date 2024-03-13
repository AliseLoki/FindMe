using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    [SerializeField] private int _loadingSceneIndex;
    [SerializeField] private CinemachineVirtualCamera _playerFollowingCamera;
    [SerializeField] private Transform _playerPosition;

    private void Awake()
    {
        _playerFollowingCamera.GetComponent<CinemachineVirtualCamera>().Follow = Player.Instance.transform;
        _playerFollowingCamera.GetComponent<CinemachineVirtualCamera>().LookAt = Player.Instance.transform;
        Player.Instance.transform.position = _playerPosition.position;
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(_loadingSceneIndex);
    }
}
