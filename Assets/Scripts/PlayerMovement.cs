using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float isMove;

    private PlayerInput playerInput;
    private UiManager uiMgr;
    private PlayerStat playerStat;
    private Rigidbody playerRigidbody;
    private Animator animationController;
    private PlayerManager mgr;
    private Camera mainCamera;
    public GameObject Center;

    private Plane GroupPlane;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        animationController = GetComponent<Animator>();
        playerStat = new PlayerStat();
        mainCamera = Camera.main;
        GroupPlane = new Plane(Vector3.up, Vector3.zero);
        playerInput = PlayerInput.instance;
        uiMgr = UiManager.instance;
        mgr = GetComponent<PlayerManager>();
    }

    private void Update()
    {
        if (uiMgr.isPause)
            return;

        if (mgr.alive)
        {
            Move();
            Rotate();
        }
    }
    private void Move()
    {
        var direction = Center.transform.forward * playerInput.moveV;
        direction.y = 0f;
        direction += Center.transform.right * playerInput.moveH;
        direction.y = 0f;

        var move = direction * playerStat.speed * Time.deltaTime;
        move.y = 0f;

        playerRigidbody.MovePosition(transform.position + move);

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
