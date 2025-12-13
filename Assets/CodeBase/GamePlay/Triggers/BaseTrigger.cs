using System;
using UnityEngine;

namespace Assets.CodeBase.GamePlay.Triggers
{
    public abstract class BaseTrigger: MonoBehaviour
    {
        public static event Action<AudioClip> Enter;
        public static event Action<AudioClip> Exit;

        protected void EnterTrigger(AudioClip clip) => 
            Enter?.Invoke(clip);

        protected void ExitTrigger(AudioClip clip) =>
            Exit?.Invoke(clip);
    }
}
