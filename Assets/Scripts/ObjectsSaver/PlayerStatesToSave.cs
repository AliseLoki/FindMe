using System;
using UnityEngine;

[Serializable]
public class PlayerStatesToSave : MonoBehaviour
{
    public Vector3 PlayerPosition;

    private bool _hasBackPack;
    private bool _hasWood;
    private bool _hasSeed;
    private bool _hasWater;
    private bool _hasSword;

    private bool _hasCow;
    private bool _hasCabbageForSeeds;
    private bool _hasTomatoForSeeds;
    //public ItemType[] Items;
    //public int Money;
    //public bool IsAlive;
}
