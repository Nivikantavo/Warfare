using UnityEngine;

public static class AnimationData
{
    public static readonly int IsRunning = Animator.StringToHash(nameof(IsRunning));
    public static readonly int IsWalking = Animator.StringToHash(nameof(IsWalking));
    public static readonly int IsDead = Animator.StringToHash(nameof(IsDead));
    public static readonly int MeleAttack = Animator.StringToHash(nameof(MeleAttack));
}
