using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] SpawnPosition;
    public GameObject[] prefebs;
    public float spawntime;
    private float dt;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < SpawnPosition.Length; i++)
        {
            Instantiate(prefebs[Random.Range(0, prefebs.Length)], SpawnPosition[i].transform);
        }
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        dt += Time.deltaTime;
        if (spawntime < dt&& player.active)
        {
            for (int i = 0; i < SpawnPosition.Length; i++)
            {
                Instantiate(prefebs[Random.Range(0, prefebs.Length - 1)], SpawnPosition[i].transform);
            }
            dt = 0;
        }

    }
}
