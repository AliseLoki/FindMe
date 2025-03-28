using UnityEngine;

namespace Triggers
{
    public class Trigger : MonoBehaviour
    {
        [SerializeField] private TriggerTypes _triggerType;

        public TriggerTypes TriggerType => _triggerType;
    }
}