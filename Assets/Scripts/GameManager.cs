using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int currentLevel = 0;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(currentLevel);
    }

    public void NextLevel()
    {
        Debug.Log("NEXT LEVEL!");
        currentLevel++;
        SceneManager.LoadScene(currentLevel);

        if (currentLevel > 0) SceneManager.UnloadSceneAsync(currentLevel-1);
    }
}
