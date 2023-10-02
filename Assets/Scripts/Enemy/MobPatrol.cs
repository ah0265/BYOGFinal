using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MobPatrol : MonoBehaviour
{

    public delegate void DoDamage();
    public static DoDamage DoDamageEvent;

    bool playerEntered = false;
    bool prevPlayerBool;
    GameObject player;
    [SerializeField] Vector3 minPos;
    [SerializeField] Vector3 maxPos;
    NavMeshAgent agent;
    Vector3 destination;
    Animator animator;
    bool reached;

    float maxHealth = 20;
    float currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        PlayerAttackInput.OnPlayerAttack += TakeDamage;
        currentHealth = maxHealth;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        MobPlace.togglePlayerBool += PlayerEnteredBoolToggle;
        FindRandomDestination();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (playerEntered)
        {
            FollowPlayer();
        }

        else
        {
            if (reached)
            {
                FindRandomDestination();
            }
            else
            {
                ReachedRandomDestination();
            }
        }

        if(player != null && (transform.position - player.transform.position).magnitude < 10f)
        {
            animator.Play("FinalBossPunch");
            FollowPlayer();
        }
        else
        {
            animator.Play("FinalBossRunning");
        }
    }

    void TakeDamage()
    {
        currentHealth -= 5;
        if (currentHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void AnimEvent()
    {
        DoDamageEvent();
    }
    void ReachedRandomDestination()
    {
        if((((transform.position - destination).magnitude < 1f && !reached)) || prevPlayerBool) {
            reached = true;
            prevPlayerBool = false;
        }
    }

    void FindRandomDestination()
    {
        destination = new Vector3(Random.Range(minPos.x, maxPos.x), 0, Random.Range(minPos.z, maxPos.z));

        agent.SetDestination(destination);

        reached = false;
    }

    void FollowPlayer()
    {
        agent.SetDestination(player.transform.position);
    }

    void PlayerEnteredBoolToggle(GameObject p)
    {
        player = p;
        prevPlayerBool = playerEntered;
        playerEntered = !playerEntered;
    }
}
