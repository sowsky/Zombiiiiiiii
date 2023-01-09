using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    public GameObject shotPos;
    private PlayerInput playerInput;
    public float shotDelay = 0.1f;
    public float range = 20f;
    public float lastFireTime;

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
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
        var ray = new Ray(shotPos.transform.position, shotPos.transform.forward); // ¹ÝÁ÷¼±
        var hitPos = Vector3.zero;

        if (Physics.Raycast(ray, out hit, range))
        {
            hitPos = hit.point;
            
        }
        else
        {
            
        }
    }
}
