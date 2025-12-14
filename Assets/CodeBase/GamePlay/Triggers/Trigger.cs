using UnityEngine;

namespace Assets.CodeBase.GamePlay.Triggers
{
    public class Trigger : BaseTrigger
    {
        [SerializeField] private AudioClip _clip;

        private void OnTriggerEnter(Collider other)
        {
            EnterTrigger(_clip);
        }

        private void OnTriggerExit(Collider other)
        {
            ExitTrigger(_clip);
        }
    }
}
