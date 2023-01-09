using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float isMove;

    private PlayerInput playerInput;
    private PlayerStat playerStat;
    private Rigidbody playerRigidbody;
    private Animator animationController;

    private Camera mainCamera;
    public GameObject Center;

    private Plane GroupPlane;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        animationController = GetComponent<Animator>();
        playerInput = GetComponent<PlayerInput>();
        playerStat = new PlayerStat();
        mainCamera = Camera.main;
        GroupPlane = new Plane(Vector3.up, Vector3.zero);
    }

    private void Update()
    {
        Move();
        Rotate();
    }
    private void Move()
    {
        var direction = Center.transform.forward * playerInput.moveV;
        direction += Center.transform.right * playerInput.moveH;

        playerRigidbody.MovePosition(transform.position + direction * playerStat.speed * Time.deltaTime);

        isMove = direction.magnitude;
        animationController.SetFloat("isMove", isMove);
    }

    private void Rotate()
    {
        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        float rayLength;
        if (GroupPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointTolook = cameraRay.GetPoint(rayLength);
            transform.LookAt(new Vector3(pointTolook.x, transform.position.y, pointTolook.z));
        }
    }
}
