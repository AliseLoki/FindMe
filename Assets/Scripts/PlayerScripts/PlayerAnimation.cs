using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimation : MonoBehaviour
{
    private const string IsWalking = nameof(IsWalking);
    private const string IsRunning = nameof(IsRunning);
    private const string IsDying = nameof(IsDying);
    private const string IsWitchAppeared = nameof(IsWitchAppeared);
    

    [SerializeField] private Player _player;

    private Animator _animatior;

    private void Awake()
    {
        _animatior = GetComponent<Animator>();
    }

    private void Update()
    {
        _animatior.SetBool(IsWalking, _player.PlayerMovement.IsWalking);
    }

    public void UseRunningAnimation(bool isUsing)
    {
        _animatior.SetBool(IsRunning, isUsing);
    }

    public void EnableDeathAnimation()
    {
        _animatior.SetTrigger(IsDying);
    }

    public void EnableIdle()
    {
        _animatior.SetTrigger(IsWitchAppeared);
    }
}
