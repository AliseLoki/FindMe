using System;
using Enemies;
using SaveSystem;
using UnityEngine;

namespace Villages
{
    public class LastVillage : Village
    {
        [SerializeField] private Spawner _spawner;

        public event Action<Witch> WitchAppeared;

        public override void GiveReward()
        {
            WitchAppeared?.Invoke(_spawner.SpawnWitch());
        }
    }
}