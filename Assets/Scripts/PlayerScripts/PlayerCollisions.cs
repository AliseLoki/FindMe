using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out InteractableObject interactableObject))
        {
            //interactableObject.Interact();
            interactableObject.EnableInteract();
        }

        if (collision.collider.TryGetComponent(out ForestTrigger forestTrigger))
        {
            Player.Instance.OnEnteredTheForest();
        }

        if (collision.collider.TryGetComponent(out SafeZoneTrigger safeZoneTrigger))
        {
            Player.Instance.OnEnteredSafeZone();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.TryGetComponent(out InteractableObject interactableObject))
        {
            //interactableObject.Interact();
            interactableObject.DisableInteract();
        }

        if (collision.collider.TryGetComponent(out SafeZoneTrigger safeZoneTrigger))
        {
            Player.Instance.OnExitSafeZone();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out GoldCoins goldCoins))
        {
            goldCoins.PickUpCoins();
            Player.Instance.OnGoldAmountChanged();
        }

        if (other.TryGetComponent(out Wood wood))
        {
            if (!Player.Instance.HasSomethingInHands)
            {
                Player.Instance.SetHasWood(true);
                Destroy(wood.gameObject);
            }
            else
            {
                print("руки заняты");
            }
        }
    }
}
