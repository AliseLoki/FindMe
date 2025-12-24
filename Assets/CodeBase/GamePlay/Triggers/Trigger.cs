using Assets.CodeBase.Infrastructure.Services.Interactions;
using UnityEngine;

namespace Assets.CodeBase.GamePlay.Triggers
{
    public class Trigger : MonoBehaviour
    {
        [SerializeField] private AudioClip _clip;
        [SerializeField] private TriggerType _type;

        private TriggerDetectionService _detectionService;

        public void Init(TriggerDetectionService triggerDetectionService) =>
            _detectionService = triggerDetectionService;

        private void OnTriggerEnter(Collider other) =>
            _detectionService?.PlayerEnteredTrigger(_type, _clip);

        private void OnTriggerExit(Collider other) =>
            _detectionService?.PlayerExitTrigger(_type);
    }
}