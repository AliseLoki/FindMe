using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out InteractableObject interactableObject))
        {
            interactableObject.Interact();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.TryGetComponent(out InteractableObject interactableObject))
        {
            interactableObject.Interact();
        }
    }
}
