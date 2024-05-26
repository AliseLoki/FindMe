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

        if (collision.collider.TryGetComponent(out Enemy enemy) && _player.HasSword)
        {
            _player.PlayerEventsHandler.OnWolfHasBeenKilled();
        }

        if (collision.collider.TryGetComponent(out Witch witch))
        {
            _player.transform.LookAt(witch.transform.position);

            if (_player.HasNecronomicon)
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
            // создать ивент , на него подписан евент хэндлер , на евент хэндлер подписаны другие компоненты
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
    }
}
