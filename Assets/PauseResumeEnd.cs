using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//https://gamedevbeginner.com/the-right-way-to-pause-the-game-in-unity/#pause_time_scale

//https://stackoverflow.com/questions/44288452/how-do-i-add-a-restart-function-to-a-game-in-unity

//https://docs.unity3d.com/ScriptReference/SceneManagement.SceneManager.LoadSceneAsync.html


public class PauseResumeEnd : MonoBehaviour
{
    public Button resetButton;
    public Button endButton;

    public static bool gameIsPaused;
    public Canvas pauseMenu; 
    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.enabled = false;
        resetButton.onClick.AddListener(() => buttonCallBack());
        endButton.onClick.AddListener(() => endbuttonCallBack());
    }
    void OnEnable()
    {
        //Register Button Event
//resetButton.onClick.AddListener(() => buttonCallBack());
       // endButton.onClick.AddListener(() => endbuttonCallBack());

    }

    private void buttonCallBack()
    {
        UnityEngine.Debug.Log("Clicked: " + resetButton.name);
        StartCoroutine(LoadYourAsyncScene());
        //  SceneManager.LoadScene(SceneManager.sceneToReset);
        //   resetGameData();
        ResumeGame(); 
    }

    private void endbuttonCallBack()
    {
        Application.Quit();
        UnityEngine.Debug.Log("Clicked: " + endButton.name);


    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Escape key was pressed");
            gameIsPaused = !gameIsPaused;
            PauseGame();
        }
        else {

        }
    }
    void PauseGame()
    {
        if (gameIsPaused)
        {
            pauseMenu.enabled = true;
            Time.timeScale = 0f;
        }
        else
        {
            pauseMenu.enabled = false;
            Time.timeScale = 1;
        }
    }

    void ResumeGame()
    {
        Time.timeScale = 1;
        pauseMenu.enabled = false;

    }

    IEnumerator LoadYourAsyncScene()
    {
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("themeparklike_entrywayscene");

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
