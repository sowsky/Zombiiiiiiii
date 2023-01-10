using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private static PlayerInput inputMgr;
    public static PlayerInput instance
    {
        get
        {
            return inputMgr == null ? FindObjectOfType<PlayerInput>() : inputMgr;
        }
    }

    public string Vertical;
    public string Horizontal;
    public string Fire;

    public float moveV;
    public float moveH;
    public bool fire;

    private void Start()
    {
        Vertical = "Vertical";
        Horizontal = "Horizontal";
        Fire = "Fire1";
    }

    private void Update()
    {
        moveV = Input.GetAxis(Vertical);
        moveH = Input.GetAxis(Horizontal);
        fire = Input.GetButton(Fire);
    }
}
