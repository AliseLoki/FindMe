using System;
using Assets.CodeBase.GamePlay.Loot;
using UnityEngine;

namespace Assets.CodeBase.Infrastructure.Services.Interactions
{
    public class PickableInteractionService 
    {
        public event Action<PickableType, AudioClip> PickableItemPicked;

        public void Pick(PickableType type, AudioClip clip)
        {
            PickableItemPicked?.Invoke(type, clip);
        }
    }
}