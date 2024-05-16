using UnityEngine;

public class LastVillage : Village
{
    [SerializeField] private Witch _witch;
   
    protected override void GiveReward()
    {
        Instantiate(_witch, transform.position, Quaternion.identity);
    }
}
