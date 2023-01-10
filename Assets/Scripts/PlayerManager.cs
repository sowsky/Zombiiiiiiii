using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int hp;
    public bool alive;
    private Animator anim;
    private float lasttimeattack;
 
    // Start is called before the first frame update
    void Start()
    {
        anim= GetComponent<Animator>();
        alive = true;
        lasttimeattack = Time.time;
    }


    // Update is called once per frame
    void Update()
    {
        if (alive&&hp < 0)
        {
            // Debug.Log(hp);
            anim.SetTrigger("Death");
            alive = false;
        }
      
    }

    private void OnTriggerStay(Collider other)
    {

        if (other.CompareTag("Monster"))
        {           
            var temp=other.GetComponent<Monster>();

            if (Time.time-lasttimeattack >= 0.5f)
            {
                lasttimeattack = Time.time;
                hp -= temp.damage;
            }                           
        }
    }

}
