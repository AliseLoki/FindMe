using System;
using UnityEngine;

public class LastVillage : Village
{
    [SerializeField] private Witch _witch;

    public event Action <Witch> WitchAppeared;

    protected override void GiveReward()
    {
        Witch witch = Instantiate(_witch, transform.position, Quaternion.identity);
        WitchAppeared?.Invoke(witch);
    }
}
