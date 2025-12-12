using System.Collections;
using Assets.CodeBase.GameConfigs;
using Assets.CodeBase.GamePlay.Hero;
using Assets.CodeBase.Infrastructure.DIContainer;
using Assets.CodeBase.Infrastructure.Services.Input;
using Assets.CodeBase.Infrastructure.StateMachine;
using Assets.CodeBase.Infrastructure.StateMachine.States;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.CodeBase.Infrastructure.EntryPoint
{
    public class BootsTrap : MonoBehaviour
    {
        [SerializeField] private GameObject _loadingCurtain;
        [SerializeField] private Configs _configs;

        private GameFSM _gameFSM;
        private Coroutine _initialRoutine;
        private DI _di;

        private void Awake()
        {   // запускать корутину со шторкой, под шторкой происходит загрузка сцены и инициализация всего и только после этого закрывается шторка
            // нужна кертен на закрытие ее 
            _initialRoutine ??= StartCoroutine(InitialRoutine());
        }

        private IEnumerator InitialRoutine()
        {
            _loadingCurtain.SetActive(true);
            DontDestroyOnLoad(this);

            _di = new DI();
            _gameFSM = new GameFSM(_di);
            _gameFSM.ChangeState<InitialState>();

            // регистрируем в нем сервисы которые будут нужны во всех сценах
            //создали сервисы
            //GameStateMachine = new GameStateMachine(new SceneLoader(coroutineRunner), loadingCurtain, AllServices.Container);
            SceneManager.LoadScene(0);
            //yield return null;
            yield return new WaitForSeconds(1);
            _loadingCurtain.SetActive(false);
            print(SceneManager.GetActiveScene().name);
            // загружается со своей позицией потом убрать
            GameObject player = Instantiate(Resources.Load<GameObject>("Player/Player"));
            Player pl = player.GetComponent<Player>();
            pl.Init(_di.GetService<IInput>(),_configs);
        }

        private void Update()
        {
            _gameFSM?.Update();
        }
    }
}
