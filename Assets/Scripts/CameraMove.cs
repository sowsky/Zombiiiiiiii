using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private GameObject player;
    private Vector3 earlyPos;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        earlyPos = new Vector3(1f, 15f, -22f);
    }

    void Update()
    {
        transform.position = earlyPos + player.transform.position;
    }
}
