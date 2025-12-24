using System;
using Assets.CodeBase.GamePlay.Triggers;
using UnityEngine;

namespace Assets.CodeBase.Infrastructure.Services.Interactions
{
    public class TriggerDetectionService
    {
        public event Action<TriggerType, AudioClip> PlayerEntered;
        public event Action<TriggerType> PlayerExited;

        public void PlayerEnteredTrigger(TriggerType type, AudioClip clip) =>
            PlayerEntered?.Invoke(type, clip);
        public void PlayerExitTrigger(TriggerType type) =>
            PlayerExited?.Invoke(type);
    }
}