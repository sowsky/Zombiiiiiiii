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

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        lineRenderer = GetComponent<LineRenderer>();
    }

    void Update()
    {   
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
            //if (hit.collider.GetComponent<Monster>())
            //{
            //    // 몬스터 찾아서 데미지 입히기
            //}
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

        lineRenderer.SetPosition(0, shotPos.transform.position);
        lineRenderer.SetPosition(1, hitPosition);
        lineRenderer.enabled = true;

        yield return new WaitForSeconds(0.02f);

        lineRenderer.enabled = false;
    }
}
