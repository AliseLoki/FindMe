using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : InteractableObject
{
    protected override void UseObject()
    {
        if (!Player.HasSomethingInHands)
        {
            //this.transform.parent = Player.HandlePoint.transform;
            //this.transform.position = Player.HandlePoint.position;
            //GetComponent<Collider>().enabled = false;
            //SelectedObject.Hide();
            //Player.SetHasSomethingInHands(true);
            //Player.SetHasWood(true);
            DisableCollider();
        }
        else
        {
            TipsViewPanel.ShowHandsAreFullTip();
        }
    }

    public void DisableCollider()
    {
        this.transform.parent = Player.HandlePoint.transform;
        this.transform.position = Player.HandlePoint.position;
        GetComponent<Collider>().enabled = false;
        SelectedObject.Hide();
        Player.SetHasSomethingInHands(true);
        Player.SetHasWood(true);
    }
}
