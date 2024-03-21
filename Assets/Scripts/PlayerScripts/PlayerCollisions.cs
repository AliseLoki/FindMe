using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out InteractableObject interactableObject))
        {
            interactableObject.Interact();
        }

        if (collision.collider.TryGetComponent(out ForestTrigger forestTrigger))
        {
            Player.Instance.OnEnteredTheForest();
        }

        if(collision.collider.TryGetComponent(out SafeZoneTrigger safeZoneTrigger))
        {
            Player.Instance.OnEnteredSafeZone();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.TryGetComponent(out InteractableObject interactableObject))
        {
            interactableObject.Interact();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out GoldCoins goldCoins))
        {
            goldCoins.PickUpCoins();
            Player.Instance.OnGoldAmountChanged();
        }

        if(other.TryGetComponent(out Wood wood))
        {
            Player.Instance.SetHasWood(true);
            Destroy(wood.gameObject);
        }
    }
}
