using System;
using UnityEngine;

public class LastVillage : Village
{
    [SerializeField] private Witch _witch;

    public event Action WitchAppeared;

    protected override void GiveReward()
    {
        Instantiate(_witch, transform.position, Quaternion.identity);
        WitchAppeared?.Invoke();
    }
}
