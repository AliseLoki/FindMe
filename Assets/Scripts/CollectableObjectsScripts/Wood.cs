using UnityEngine;

public class Wood : InteractableObject
{
    protected override void UseObject()
    {
        if (!Player.PlayerHands.HasSomethingInHands)
        {
            DisableCollider();
        }
        else
        {
            TipsViewPanel.ShowHandsAreFullTip();
        }
    }

    public void DisableCollider()
    {
        //очень странный метод
        this.transform.parent = Player.HandlePoint.transform;
        this.transform.position = Player.HandlePoint.position;
        GetComponent<Collider>().enabled = false;
        SelectedObject.Hide();
        Player.SetHasSomethingInHands(true);
        Player.SetHasWood(true);
    }
}
