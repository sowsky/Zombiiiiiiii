using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    public GameObject shotPos;
    private PlayerInput playerInput;
    private float shotDelay = 0.1f;
    private float range = 20f;
    private float lastFireTime;
    private LineRenderer lineRenderer;
    public ParticleSystem gunParticle;
    private UiManager uiMgr;
    public ParticleSystem blood;
    public AudioClip Shootsound;
    private AudioSource audio;

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        lineRenderer = GetComponent<LineRenderer>();
        uiMgr = UiManager.instance;
        audio=GetComponent<AudioSource>(); 
    }

    void Update()
    {   
        if (uiMgr.isPause)
            return;

        if (playerInput.fire && Time.time - lastFireTime > shotDelay)
            Shot();
    }

    void Shot()
    {
        lastFireTime = Time.time;

        RaycastHit hit;
        var ray = new Ray(shotPos.transform.position, shotPos.transform.forward);
        var hitPos = Vector3.zero;

        if (Physics.Raycast(ray, out hit, range))
        {            
            hitPos = hit.point;
            if (hit.collider.GetComponent<Monster>())
            {
                var hitPoint = hit.collider.ClosestPoint(transform.position);
                var hitNormal = transform.position - hit.transform.position;
                var temp = hit.collider.GetComponent<Monster>();
                temp.hp -= 50;
                blood.transform.position = hitPoint;
                blood.transform.rotation = Quaternion.LookRotation(hitNormal);
                blood.Play();
            }
        }
        else
        {
            hitPos = shotPos.transform.position + (shotPos.transform.forward * range);
        }

        StartCoroutine(ShotEffect(hitPos));
    }

    private IEnumerator ShotEffect(Vector3 hitPosition)
    {
        gunParticle.Play();
        audio.PlayOneShot(Shootsound);

        lineRenderer.SetPosition(0, shotPos.transform.position);
        lineRenderer.SetPosition(1, hitPosition);
        lineRenderer.enabled = true;

        yield return new WaitForSeconds(0.01f);

        lineRenderer.enabled = false;
    }
}
