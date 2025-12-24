using Assets.CodeBase.GamePlay.Hero;
using Assets.CodeBase.GamePlay.Loot;
using Assets.CodeBase.GamePlay.Triggers;
using Assets.CodeBase.Infrastructure.DIContainer;
using Assets.CodeBase.Infrastructure.Services.Audio;
using Assets.CodeBase.Infrastructure.Services.Fabrica;
using Assets.CodeBase.Infrastructure.Services.Interactions;
using Assets.CodeBase.Infrastructure.Services.Inventory;
using Enemies;
using UnityEngine;

namespace Assets.CodeBase.Infrastructure.EntryPoint
{
    public class SceneScope : MonoBehaviour
    {
        [SerializeField] private AudioService _audioService;
        [SerializeField] private Transform _spawnPlaces;
        [SerializeField] private Trigger[] _triggers;
        [SerializeField] private Transform _enemyPatrolPoints;

        private Enemy[] _enemies = new Enemy[2];

        private DI _di;
        private Player _player;
        private IFactory _factory;
        private PickableInteractionService _pickableInteractionService;
        private TriggerDetectionService _triggerDetectionService;
        private InventoryService _inventoryService;

        private bool _playerIsInForest;

        private void OnEnable()
        {
            //
            _pickableInteractionService = new PickableInteractionService();
            _inventoryService = new InventoryService();
            _triggerDetectionService = new TriggerDetectionService();

            foreach (var trigger in _triggers)
            {
                trigger.Init(_triggerDetectionService);
            }

            _triggerDetectionService.PlayerEntered += OnPlayerEnterTrigger;
            _triggerDetectionService.PlayerExited += OnPlayerExitTrigger;

            _pickableInteractionService.PickableItemPicked += OnItemPicked;
        }

        private void OnDisable()
        {
            _triggerDetectionService.PlayerEntered -= OnPlayerEnterTrigger;
            _triggerDetectionService.PlayerExited -= OnPlayerExitTrigger;

            _pickableInteractionService.PickableItemPicked -= OnItemPicked;
        }

        public void Init(DI di, Player player)
        {
            _di = di;
            _player = player;
            _factory = _di.GetService<IFactory>();

            _audioService.PlayBackgroundMusic(_audioService.DefaultClip);
            _factory.SpawnLoot(_spawnPlaces.transform, _pickableInteractionService, transform);
            _enemies = _factory.SpawnEnemies(_enemyPatrolPoints, _player.transform);
        }

        private void OnItemPicked(PickableType type, AudioClip clip)
        {
            _audioService.PlayEffect(clip);
            _inventoryService.AddItem(type);
            // добавили в инвентарь по типу
        }

        private void OnPlayerEnterTrigger(TriggerType type, AudioClip clip)
        {
            // не забыть что волк начнет охотиться за игрком при заходе в лес
            if (type == TriggerType.Forest)
            {

                _playerIsInForest = true;

                    foreach ( Enemy enemy in _enemies)
                    {
                        enemy.OnPlayerEnteredTheForest();
                    }
            }
            else 
            {
                _playerIsInForest = false;

                foreach (Enemy enemy in _enemies)
                {
                    enemy.OnPlayerEnteredSafeZone();
                }
            }

            _audioService.PlayBackgroundMusic(clip);
        }

        private void OnPlayerExitTrigger(TriggerType type)
        {
            if (!_playerIsInForest)
            {
                _audioService.PlayBackgroundMusic(_audioService.DefaultClip);

                foreach (Enemy enemy in _enemies)
                {
                    enemy.OnPlayerEnteredSafeZone();
                }
            }
        }
    }
}
