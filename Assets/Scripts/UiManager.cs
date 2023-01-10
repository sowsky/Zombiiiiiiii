using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class UiManager : MonoBehaviour
{
    public bool isPause = false;
    public GameObject pauseMenu;
    private static UiManager uiMgr;
    public TextMeshProUGUI score;
    public TextMeshProUGUI gameover;
    private int scorenum = 0;
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

    public void Score(int num)
    {
        scorenum += num;
        score.text = "SCORE : " + scorenum;
    }

    public void GameOver() {
        gameover.gameObject.SetActive(true);
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
