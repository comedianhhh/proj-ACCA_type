//By Xiang Tianyu 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    [SerializeField] private float timer = 300f;

    public Text timerText;

    private bool isTimeOut = false;

    public GameObject winPanel;

    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;


    void Awake()
    {
        winPanel.SetActive(false);
        pauseMenuUI.SetActive(false); 
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Timer();
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                Resume();
            }
            else
           {
               Pause();
           }
        }
    }

    private void Timer()
    {
        if(isTimeOut==false)
        {
            timer -= Time.deltaTime;
            timerText.text = timer.ToString("F1");
            if (timer <= 0)
            {
                isTimeOut = true;
                timerText.text = "0";
                //StartCoroutine("ShowWinPanel");
                winPanel.SetActive(true);
                Time.timeScale = 0.0f;
            }
        }
    }
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0.0f;
        GameIsPaused = true;
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1.0f;
        GameIsPaused = false;
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1.0f;
        GameIsPaused = false;
    }
    public void Exit()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Demo_MenuPage");
    }

    public void Back()
    {
        SceneManager.LoadScene(3);
    }

}
