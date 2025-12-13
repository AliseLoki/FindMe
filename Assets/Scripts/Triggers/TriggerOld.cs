using UnityEngine;

namespace Triggers
{
    public class TriggerOld : MonoBehaviour
    {
        [SerializeField] private TriggerTypesOld _triggerType;
        [SerializeField] private AudioClip _clip;

        public AudioClip Clip => _clip;

        public TriggerTypesOld TriggerType => _triggerType;
    }
}