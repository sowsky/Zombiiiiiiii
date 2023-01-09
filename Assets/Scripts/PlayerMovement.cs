using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class PlayerMovement : MonoBehaviour
{
    public LayerMask ground;

    public float isMove;
    public bool isDead = true;

    public float moveV;
    public float moveH;

    public PlayerInput playerInput;
    public PlayerStat playerStat;
    public Rigidbody playerRigidbody;
    public Animator animationController;

    public 

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        animationController = GetComponent<Animator>();
        playerInput = new PlayerInput();
        playerStat = new PlayerStat();
    }

    void Update()
    {
        moveV = Input.GetAxis(playerInput.moveVAxisName);
        moveH = Input.GetAxis(playerInput.moveHAxisName);

        var direction = transform.forward * moveV;
        direction += transform.right * moveH;
        playerRigidbody.MovePosition(transform.position + direction * playerStat.speed * Time.deltaTime);

        isMove = direction.magnitude;
        animationController.SetBool("isDead", isDead);
        animationController.SetFloat("isMove", isMove);

        //Quaternion newRotate = Quaternion.LookRotation(Input.mousePosition);
        //playerRigidbody.rotation = Quaternion.Lerp(playerRigidbody.rotation, newRotate, playerStat.speed);
    }
}
