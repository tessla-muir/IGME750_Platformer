using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.name == "Player")
        {
            Debug.Log("DEATH");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
