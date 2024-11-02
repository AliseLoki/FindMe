using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerCookingModule _playerCookingModule;
    [SerializeField] private PlayerInventory _playerInventory;
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private PlayerHands _playerHands;
    [SerializeField] private PlayerSoundEffects _playerSoundEffects;
    [SerializeField] private PlayerAnimation _playerAnimation;
    [SerializeField] private PlayerRagdollController _playerRagdollController;
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private PlayerGold _playerGold;
    [SerializeField] private PlayerCollisions _playerCollisions;
 
    public PlayerCollisions PlayerCollisions => _playerCollisions;

    public PlayerMovement PlayerMovement => _playerMovement;

    public PlayerCookingModule PlayerCookingModule => _playerCookingModule;

    public PlayerInventory PlayerInventory => _playerInventory;

    public PlayerHands PlayerHands => _playerHands;

    public PlayerSoundEffects PlayerSoundEffects => _playerSoundEffects;

    public PlayerAnimation PlayerAnimation => _playerAnimation;

    public PlayerRagdollController PlayerRagdollController => _playerRagdollController;

    public PlayerHealth PlayerHealth => _playerHealth;

    public PlayerGold PlayerGold => _playerGold;
}
