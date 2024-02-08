using UnityEngine;

public class RussianOven : MonoBehaviour
{
    [SerializeField] private WoodInOven _woodInOven;
    [SerializeField] private WaterInPan _waterInPan;

    public WoodInOven Wood => _woodInOven;
    public WaterInPan Water => _waterInPan;
}
