using UnityEngine;

namespace Triggers
{
    public class Trigger : MonoBehaviour
    {
        [SerializeField] private TriggerTypes _triggerType;
        [SerializeField] private AudioClip _clip;

        public AudioClip Clip => _clip;

        public TriggerTypes TriggerType => _triggerType;
    }
}