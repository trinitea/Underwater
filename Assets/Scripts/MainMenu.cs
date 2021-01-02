using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Slider slider;
   // public GameObject loadingBar;
    public bool loadData;

    public static MainMenu Instance;

    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        
    }



    public void Start()
    {


        //slider = loadingBar.GetComponent<Slider>();
        //loadingBar = GameObject.FindWithTag("startSlider");

    }


    public void PlayGame(int sceneIndex)
    {
        StartCoroutine(LoadAsynchronously(sceneIndex));
       
    }

    public void PlaySaveGame(int sceneIndex)
    {
        StartCoroutine(LoadAsynchronously(sceneIndex));
        loadData = true;

    }

    IEnumerator LoadAsynchronously (int sceneIndex )
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            Debug.Log(progress);
            yield return null;
        }
    }

    
}
