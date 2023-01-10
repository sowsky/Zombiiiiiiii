using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
    private NavMeshAgent pathFinder; // 경로계산 AI 에이전트
    private Animator animator;
    public int hp;
    public int speed;
    public int damage;
    private GameObject player;
    private PlayerManager playermanager;
    public AudioClip hurtclip;
    public AudioClip deathclip;
    public AudioSource audio;
    private CapsuleCollider cap;
    private bool Isdead;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playermanager= player.GetComponent<PlayerManager>();
        audio= GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        pathFinder = GetComponent<NavMeshAgent>();
        animator.SetBool("IsMoving", true);
        Isdead = false;
        cap= GetComponent<CapsuleCollider>();
    }

    IEnumerator Destoryed(float delay)
    {
        audio.PlayOneShot(deathclip);

        pathFinder.isStopped = true;

        speed = 0;
        animator.SetTrigger("Death");

        yield return new WaitForSeconds(delay);

        Destroy(gameObject);
        
    }
    // Update is called once per frame
    void Update()
    {      

        if (hp < 0&&!Isdead)
        {
            var colliders = GetComponents<Collider>();
            foreach (var collider in colliders)
            {
                collider.enabled = false;
            }
            StartCoroutine(Destoryed(3));
            Isdead = true;
        }
        else if(!Isdead&& playermanager.alive)
        {            
            if(Input.GetKeyDown(KeyCode.F)) {
                hp = -1;
            }
            pathFinder.SetDestination(player.transform.position);
        }
        if (!playermanager.alive)
        {
            pathFinder.isStopped = true;

            animator.SetBool("IsMoving", false);
        }
    }

    //private IEnumerator UpdatePath()
    //{
    //    // 살아있는 동안 무한 루프
    //    //while (!dead)
    //    //{
    //    //    if (hasTarget)
    //    //    {
    //    //        pathFinder.isStopped = false;
    //    //        pathFinder.SetDestination(targetEntity.transform.position);
    //    //    }
    //    //    else
    //    //    {
    //    //        pathFinder.isStopped = true;

    //    //        var colliders = Physics.OverlapSphere(transform.position, range, whatIsTarget);
    //    //        foreach (var collider in colliders)
    //    //        {
    //    //            var entity = collider.GetComponent<LivingEntity>();
    //    //            if (entity != null)
    //    //            {
    //    //                targetEntity = entity;
    //    //                break;
    //    //            }
    //    //        }
    //    //    }

    //    //    // 0.25초 주기로 처리 반복
    //    //    yield return new WaitForSeconds(0.25f);
    //    }
    //}
}
