using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class ToggleFireBall : MonoBehaviour
{
    [SerializeField] GameObject fireBall;
    [SerializeField] Animator animator;
    [SerializeField] float projectileSpeed;
    [SerializeField] float animDelayTime = 0.8f;
    private void Start()
    {
        InputManager.SpellEvent += TheFireBall;
    }

    void TheFireBall(string[] array)
    {
        string[] localArray = array;
        if (localArray[0] == "l" && localArray[1] == "l" && localArray[2] == "i")
        {
            animator.Play("FireBallSpell");
            StartCoroutine(SpellAnim());
        }
    }

    IEnumerator SpellAnim()
    {
        yield return new WaitForSeconds(animDelayTime);
        GameObject clone = Instantiate(fireBall, this.transform.position, Quaternion.identity);

        //clone.GetComponent<Rigidbody>().AddRelativeForce(transform.TransformDirection(Vector3.forward).normalized * projectileSpeed, ForceMode.Impulse);

        clone.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.forward) * projectileSpeed;

        Destroy(clone, 2f);

        animator.Play("Idle");
    }
}
