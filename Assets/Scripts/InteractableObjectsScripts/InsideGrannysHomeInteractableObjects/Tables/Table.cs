using System.Collections.Generic;
using SO;
using UnityEngine;

namespace Interactables.Containers.Tables
{
    public abstract class Table : Container
    {
        [SerializeField] protected Transform PlaceForFood;
        [SerializeField] private List<AudioClip> _audioClips;

        protected bool IsChangedFood;

        public List<AudioClip> AudioClips => _audioClips;

        protected override void UseObject()
        {
            if (FoodSO == null && Player.PlayerHands.HasSomethingInHands)
            {
                PutFood();
            }
            else if (FoodSO != null && !Player.PlayerHands.HasSomethingInHands)
            {
                DoSomething();
            }
        }

        protected abstract void DoSomething();

        protected abstract void PutFood();

        protected void ResetFoodAndFoodSO()
        {
            Food = null;
            FoodSO = null;
        }

        protected void IniTFoodAndFoodSO(Food food, FoodSO foodSO)
        {
            Food = food;
            FoodSO = foodSO;
        }
    }
}