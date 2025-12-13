using Assets.CodeBase.GamePlay.Triggers;
using Assets.CodeBase.Infrastructure.Services.Audio;
using UnityEngine;

namespace Assets.CodeBase.Infrastructure.EntryPoint
{
    public class SceneScope : MonoBehaviour
    {
        [SerializeField] private AudioService _audioService;

        private void OnEnable()
        {
            BaseTrigger.Enter += OnBaseTriggerEnter;
            BaseTrigger.Exit += OnBaseTriggerExit;
        }

        private void Start()
        {
            _audioService.PlayBackgroundMusic(_audioService.DefaultClip);            
        }

        private void OnDisable()
        {
            BaseTrigger.Enter -= OnBaseTriggerEnter;
            BaseTrigger.Exit -= OnBaseTriggerExit;
        }

        private void OnBaseTriggerEnter(AudioClip clip)
        {   
            _audioService.PlayBackgroundMusic(clip);
        }

        private void OnBaseTriggerExit(AudioClip clip)
        {
            _audioService.PlayBackgroundMusic(_audioService.DefaultClip);
        }
    }
}
