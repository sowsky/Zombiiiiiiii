using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    private PlayerManager player;
    private Slider slide;
    // Start is called before the first frame update
    void Start()
    {
        player= GameObject.FindWithTag("Player").GetComponent<PlayerManager>();
        slide=GetComponent<Slider>();  
        
    }

    // Update is called once per frame
    void Update()
    {
        slide.value = player.hp;
    }
}
