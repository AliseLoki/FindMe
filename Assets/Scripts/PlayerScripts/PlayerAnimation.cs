using UnityEngine;

[RequireComponent (typeof(Animator))]
public class PlayerAnimation : MonoBehaviour
{
   private const string IsWalking = nameof(IsWalking);

    [SerializeField] private PlayerMovement _player;

    private Animator _animatior;

    private void Awake()
    {
        _animatior = GetComponent<Animator>();
    }

    private void Update()
    {
        _animatior.SetBool(IsWalking,_player.IsWalking);
    }
}
