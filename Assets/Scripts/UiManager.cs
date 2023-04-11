using UnityEngine;
using TMPro;

public class UiManager : MonoBehaviour
{
    public bool isPause = false;
    public GameObject pauseMenu;
    private static UiManager uiMgr;
    private SoundManager soundMgr;
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
            if(pauseMenu.activeSelf)
            {
                if (soundMgr == null)
                    soundMgr = FindObjectOfType<SoundManager>();
                
                if (soundMgr != null)
                    soundMgr.effects = FindObjectsOfType<AudioSource>();
            }
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

    public void GameQuit()
    {
        Application.Quit();
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        isPause = false;
    }    
}
