using UnityEngine;

public class BaseView
{
    private readonly int IsIdle = Animator.StringToHash(nameof(IsIdle));
    private readonly int Ride = Animator.StringToHash(nameof(Ride));
    private readonly int RideBack = Animator.StringToHash(nameof(RideBack));
    private readonly int Destroyed = Animator.StringToHash(nameof(Destroyed));
    private readonly int TakeDamage = Animator.StringToHash(nameof(TakeDamage));

    private Animator _animator;

    public BaseView(Animator animator)
    {
        _animator = animator;
    }

    public void StartIdle() => _animator.SetBool(IsIdle, true);
    public void StopIdle() => _animator.SetBool(IsIdle, false);

    public void StartRide() => _animator.SetBool(Ride, true);
    public void StopRide() => _animator.SetBool(Ride, false);

    public void StartRideBack() => _animator.SetBool(RideBack, true);
    public void StopRideBack() => _animator.SetBool(RideBack, false);

    public void StartDestroyed() => _animator.SetBool(Destroyed, true);
    public void StopDestroyed() => _animator.SetBool(Destroyed, false);

    public void StartTakeDamage() => _animator.SetTrigger(TakeDamage);
}
