using Assets.CodeBase.GameConfigs;
using Assets.CodeBase.Infrastructure.DIContainer;
using Assets.CodeBase.Infrastructure.Services.SceneLoaders;
using Assets.CodeBase.Infrastructure.StateMachine;
using Assets.CodeBase.Infrastructure.StateMachine.States;
using UnityEngine;

namespace Assets.CodeBase.Infrastructure.EntryPoint
{
    public class BootsTrap : MonoBehaviour, ICoroutineRunner
    {
        [SerializeField] private GameObject _loadingCurtain;
        [SerializeField] private Configs _configs;

        private GameFSM _gameFSM;
        private DI _di;
        private SceneLoader _sceneLoader;

        private void Awake()
        {
            DontDestroyOnLoad(this);
            _loadingCurtain.SetActive(true);

            _di = new DI();
            _sceneLoader = new SceneLoader(this);
            _gameFSM = new GameFSM(_di, this, _sceneLoader, _configs, _loadingCurtain);
            _gameFSM.ChangeState<InitialState>();
        }

        private void Update()
        {
            _gameFSM?.Update();
        }
    }
}
