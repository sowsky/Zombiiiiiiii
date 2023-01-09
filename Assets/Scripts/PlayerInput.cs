using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public string Vertical = "Vertical";
    public string Horizontal = "Horizontal";
    public string Fire = "Fire1";

    public float moveV;
    public float moveH;
    public bool fire;

    private void Update()
    {
        moveV = Input.GetAxis(Vertical);
        moveH = Input.GetAxis(Horizontal);
        fire = Input.GetButton(Fire);
    }
}
