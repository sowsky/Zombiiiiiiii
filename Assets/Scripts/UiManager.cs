using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public bool isPause = false;
    public GameObject pauseMenu;
    private static UiManager uiMgr;
    public static UiManager instance
    {
        get
        {
            return uiMgr == null ? FindObjectOfType<UiManager>() : uiMgr;
        }
    }
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.SetActive(!pauseMenu.activeSelf);
            Pause();
        }
    }

    private void Pause()
    {
        if (pauseMenu.activeSelf)
        {
            if (!isPause)
            {
                Time.timeScale = 0f;
                isPause = true;
            }
        }
        else
        {
            if (isPause)
            {
                Time.timeScale = 1f;
                isPause = false;
            }
        }
    }
}
