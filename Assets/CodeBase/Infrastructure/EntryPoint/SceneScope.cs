using Assets.CodeBase.GamePlay.Hero;
using Assets.CodeBase.GamePlay.Loot;
using Assets.CodeBase.GamePlay.Triggers;
using Assets.CodeBase.Infrastructure.DIContainer;
using Assets.CodeBase.Infrastructure.Services.Audio;
using Assets.CodeBase.Infrastructure.Services.Fabrica;
using Assets.CodeBase.Infrastructure.Services.Interactions;
using UnityEngine;

namespace Assets.CodeBase.Infrastructure.EntryPoint
{
    public class SceneScope : MonoBehaviour
    {
        [SerializeField] private AudioService _audioService;
        [SerializeField] private Transform _spawnPlaces;

        private DI _di;
        private Player _player;
        private IFactory _factory;
        private PickableInteractionService _pickableInteractionService;

        private void OnEnable()
        {
            _pickableInteractionService = new PickableInteractionService();
            _pickableInteractionService.PickableItemPicked += OnItemPicked;

            BaseTrigger.Enter += OnBaseTriggerEnter;
            BaseTrigger.Exit += OnBaseTriggerExit;
        }

        private void OnDisable()
        {
            BaseTrigger.Enter -= OnBaseTriggerEnter;
            BaseTrigger.Exit -= OnBaseTriggerExit;
        }

        public void Init(DI di, Player player)
        {
            _di = di;
            _player = player;
            _factory = _di.GetService<IFactory>();

            _audioService.PlayBackgroundMusic(_audioService.DefaultClip);
            _factory.SpawnLoot(_spawnPlaces.transform, _pickableInteractionService,transform);
        }

        private void OnItemPicked(PickableType type, AudioClip clip)
        {
            _audioService.PlayEffect(clip);
            // добавили в инвентарь по типу
        }

        private void OnBaseTriggerEnter(AudioClip clip)
        {
            // не забыть что волк начнет охотиться за игрком при заходе в лес

            _audioService.PlayBackgroundMusic(clip);
        }

        private void OnBaseTriggerExit(AudioClip clip)
        {
            _audioService.PlayBackgroundMusic(_audioService.DefaultClip);
        }
    }
}
