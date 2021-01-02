using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject GameManager;


    public Button button1;
    public Button button2;
    public bool selected;

    // Update is called once per frame

    public void Awake()
    {
        GameManager = GameObject.FindGameObjectWithTag("gameManager");
    }

    void OnEnable()
    {
        selected = false;
    }

    void OnDisable()
    {
        selected = false;
    }



    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (GameIsPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }


        if(selected== false)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                button2.Select();
                selected = true;
            }

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                button1.Select();
                selected = true;
            } 
        }
        

    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        selected = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void QuitToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        Destroy(GameManager);
    }
}
