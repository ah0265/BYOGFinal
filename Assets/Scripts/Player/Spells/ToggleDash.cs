using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleDash : MonoBehaviour
{
    [SerializeField] float dashTime;
    [SerializeField] float dashSpeed;
    CharacterController controller;
    Animator animator;
    AnimatorClipInfo[] clipsInfo;
    // Start is called before the first frame update
    void Start()
    {
        InputManager.SpellEvent += DashSpell;
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }


    void DashSpell(string[] array)
    {

        clipsInfo = this.animator.GetCurrentAnimatorClipInfo(0);
        string currentClip = clipsInfo[0].clip.name;
        string[] localArray = array;
        if (localArray[0] == "j" && localArray[1] == "l" && localArray[2] == "j")
        {
            StartCoroutine(Dash(currentClip));
        }
    }

    IEnumerator Dash(string s)
    {
        float startTime = Time.time;

        while(Time.time < startTime + dashTime)
        {
            controller.Move(transform.TransformDirection(Vector3.forward) * dashSpeed * Time.deltaTime);
            animator.Play("DashSpell");
            yield return null;
        }
        PlayerMovement.isMoving = false;

        animator.Play(s);
    }
}
