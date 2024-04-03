using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out InteractableObject interactableObject))
        {
            interactableObject.EnableInteract();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.TryGetComponent(out InteractableObject interactableObject))
        {
            interactableObject.DisableInteract();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out GoldCoins goldCoins))
        {
            goldCoins.PickUpCoins();
            Player.Instance.PlayerEventsHandler.OnGoldAmountChanged();
            // создать ивент , на него подписан евент хэндлер , на евент хэндлер подписаны другие компоненты
        }

        if (other.TryGetComponent(out Wood wood))
        {
            if (!Player.Instance.HasSomethingInHands)
            {
                Player.Instance.SetHasWood(true);
                Destroy(wood.gameObject);
                TipsViewPanel.Instance.ShowPutWoodInOvenTip();
            }
            else
            {
                TipsViewPanel.Instance.ShowHandsAreFullTip();
            }
        }

        if (other.TryGetComponent(out ForestTrigger forestTrigger))
        {
            Player.Instance.PlayerEventsHandler.OnEnteredTheForest();
        }

        if(other.TryGetComponent(out GrannysHomeTrigger grannysHomeTrigger))
        {
            Player.Instance.PlayerEventsHandler.OnEnteredGrannysHome();
        }

        if(other.TryGetComponent(out VillageZoneTrigger villageZoneTrigger))
        {
            Player.Instance.PlayerEventsHandler.OnEnteredVillage();
        }

        if (other.TryGetComponent(out SafeZoneTrigger safeZoneTrigger))
        {
            Player.Instance.PlayerEventsHandler.OnEnteredSafeZone();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out GrannysHomeTrigger grannysHomeTrigger))
        {
            Player.Instance.PlayerEventsHandler.OnExitGrannysHome();
        }

        if (other.TryGetComponent(out VillageZoneTrigger villageZoneTrigger))
        {
            Player.Instance.PlayerEventsHandler.OnExitVillage();
        }

        if (other.TryGetComponent(out SafeZoneTrigger safeZoneTrigger))
        {
            Player.Instance.PlayerEventsHandler.OnExitSafeZone();
        }
    }
}
