using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    [SerializeField] private bool _hasFirewood;
    [SerializeField] private bool _hasWater;
    [SerializeField] private LayerMask _layerMask;

    //private void Update()
    //{
    //    if(Physics.Raycast(transform.position,transform.forward, out RaycastHit hitInfo, 1f, _layerMask))
    //    {
    //      hitInfo.collider.GetComponent<InteractableObject>().Interact();
    //    }
    //    else
    //    {
    //        hitInfo.collider.GetComponent<InteractableObject>().Interact();
    //    }
    //}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out Firewood firewood))
        {
            print("take firewood");
            _hasFirewood = true;
            Destroy(firewood.gameObject);
        }

        if (collision.collider.TryGetComponent(out BucketOfWater bucketOfWater))
        {
            print("take water");
            _hasWater = true;
            Destroy(bucketOfWater.gameObject);
        }

        if (collision.collider.TryGetComponent(out RussianOven russianOven))
        {
            if (_hasFirewood)
            {
                russianOven.Wood.PutWood();
            }

            if(_hasWater)
            {
                russianOven.Water.PutWater();
            }
        }

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
