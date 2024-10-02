using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerCollisions : MonoBehaviour
{
    private int _coinsValue = 1;

    private Player _player;

    private void Awake()
    {
        _player = GetComponent<Player>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out InteractableObject interactableObject))
        {
            interactableObject.EnableInteract();
        }

        if (collision.collider.TryGetComponent(out Enemy enemy) && _player.PlayerHands.HoldableObject == HoldableObjects.Sword)
        {
             _player.PlayerEventsHandler.OnWolfHasBeenKilled();
            _player.PlayerHands.GiveObject();
        }

        if (collision.collider.TryGetComponent(out Witch witch))
        {
            if (_player.PlayerHands.HasNecronomicon)
            {
                _player.PlayerEventsHandler.OnWitchHasBeenAttacked();
            }
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
            _player.PlayerEventsHandler.OnGoldAmountChanged(_coinsValue);
        }

        if (other.TryGetComponent(out ForestTrigger forestTrigger))
        {
            _player.PlayerEventsHandler.OnEnteredTheForest();
        }

        if (other.TryGetComponent(out GrannysHomeTrigger grannysHomeTrigger))
        {
            _player.PlayerEventsHandler.OnEnteredGrannysHome();
        }

        if (other.TryGetComponent(out VillageZoneTrigger villageZoneTrigger))
        {
            _player.PlayerEventsHandler.OnEnteredVillage();
        }

        if (other.TryGetComponent(out SafeZoneTrigger safeZoneTrigger))
        {
            _player.PlayerEventsHandler.OnEnteredSafeZone();
        }

        if (other.TryGetComponent(out PlaceForPentagramTrigger placeForPentagramTrigger))
        {
            _player.PlayerEventsHandler.OnEnteredPentagramZone();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out GrannysHomeTrigger grannysHomeTrigger))
        {
            _player.PlayerEventsHandler.OnExitGrannysHome();
        }

        if (other.TryGetComponent(out VillageZoneTrigger villageZoneTrigger))
        {
            _player.PlayerEventsHandler.OnExitVillage();
        }

        if (other.TryGetComponent(out SafeZoneTrigger safeZoneTrigger))
        {
            _player.PlayerEventsHandler.OnExitSafeZone();
        }

        if (other.TryGetComponent(out PlaceForPentagramTrigger placeForPentagramTrigger))
        {
            _player.PlayerEventsHandler.OnExitPentagramZone();
        }
    }
}
