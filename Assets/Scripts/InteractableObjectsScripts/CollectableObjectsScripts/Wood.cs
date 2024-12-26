using UIPanels;

namespace Interactables
{
    public class Wood : InteractableObject
    {
        protected override void UseObject()
        {
            if (!Player.PlayerHands.HasSomethingInHands)
            {
                DisableCollider();
                Player.PlayerHands.TakeObject(this.gameObject, HoldableObjects);
            }
            else
            {
                TipsViewPanel.ShowHandsAreFullTip();
            }
        }
    }
}
