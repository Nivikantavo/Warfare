using UnityEngine;

public class UnitView
{
    private readonly int IsIdle = Animator.StringToHash(nameof(IsIdle));
    private readonly int IsRunning = Animator.StringToHash(nameof(IsRunning));
    private readonly int IsWalking = Animator.StringToHash(nameof(IsWalking));
    private readonly int IsDead = Animator.StringToHash(nameof(IsDead));
    private readonly int MeleAttack = Animator.StringToHash(nameof(MeleAttack));

    private Animator _animator;

    public UnitView(Animator animator)
    {
        _animator = animator;
    }

    public void StartIdle() => _animator.SetBool(IsIdle, true);
    public void StopIdle() => _animator.SetBool(IsIdle, false);

    public void StartRunning() => _animator.SetBool(IsRunning, true);
    public void StopRunning() => _animator.SetBool(IsRunning, false);

    public void StartWalkingt() => _animator.SetBool(IsWalking, true);
    public void StopWalking() => _animator.SetBool(IsWalking, false);

    public void StartDieing() => _animator.SetBool(IsDead, true);
    public void StopDieing() => _animator.SetBool(IsDead, false);

    public void StartMeleAttack() => _animator.SetTrigger(MeleAttack);

}
