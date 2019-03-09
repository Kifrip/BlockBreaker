using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    //[SerializeField] Scene level;

    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
        FindObjectOfType<GameSession>().ResetGame();
    }

    public void LoadSuccessScene()
    {
        SceneManager.LoadScene("Success Screen");
    }

    public void LoadLevelsScene()
    {
        SceneManager.LoadScene("Levels");
    }

    public void LoadLevelByIndex(int ScendeIndex)
    {
        SceneManager.LoadScene(ScendeIndex);
    }

    public void LoadLevelByName(string ScendeName)
    {
        SceneManager.LoadScene(ScendeName);
    }

    //public void loadlevel1()
    //{
    //    scenemanager.loadscene(1);
    //}

    //public void loadlevel2()
    //{
    //    scenemanager.loadscene(2);
    //}

    //public void loadlevel3()
    //{
    //    scenemanager.loadscene(3);
    //}

    public void QuitGame()
    {
        Application.Quit();
    }
}
