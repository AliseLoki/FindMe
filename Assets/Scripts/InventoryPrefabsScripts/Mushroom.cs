using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  abstract class Mushroom : InteractableObject
{
    protected override void UseObject()
    {
       Destroy(gameObject);
    }
}
