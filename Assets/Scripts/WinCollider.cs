using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.name == "Player")
        {
            Debug.Log("WIN");
            int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
            
            if (nextSceneIndex > SceneManager.sceneCountInBuildSettings)
            {
                Debug.Log("ERROR: Next scene index is out of range.");
            }
            else
            {
                SceneManager.LoadScene(nextSceneIndex);
            }
        }
    }
}
