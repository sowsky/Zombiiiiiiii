using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public int hp;
    public bool alive;
    private Animator anim;
    private float lasttimeattack;
 
    // Start is called before the first frame update
    void Awake()
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
            var colliders = GetComponents<Collider>();
            foreach (var collider in colliders)
            {
                collider.enabled = false;
            }
            UiManager.instance.GameOver();
            StartCoroutine(Restart());
        }
      
    }

    private IEnumerator Restart()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

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
