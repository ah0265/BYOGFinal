using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerAttackInput : MonoBehaviour
{
    Movements movements;
    public delegate void PlayerAttack();
    public static event PlayerAttack OnPlayerAttack;
    Animator animator;
    AnimatorClipInfo[] clipsInfo;
    string currentClip;
    private void Awake()
    {
        movements = new Movements();
        animator = GetComponent<Animator>();
    }
    private void OnEnable()
    {
        movements.Enable();
        movements.Land.Attack.started += _ => InputAccepted();
    }

    void InputAccepted()
    {
        clipsInfo = this.animator.GetCurrentAnimatorClipInfo(0);
        currentClip = clipsInfo[0].clip.name;
        animator.Play("PlayerAttack");
    }

    public void Attacking()
    {
        
        OnPlayerAttack();
    }

    public void AttackEnded()
    {
        animator.Play(currentClip);
    }
}
