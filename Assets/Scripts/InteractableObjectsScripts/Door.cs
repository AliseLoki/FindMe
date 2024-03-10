using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : InteractableObject
{
    protected override void UseObject()
    {
        print("GO AWAY");
    }
}
