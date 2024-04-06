using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathHeight : MonoBehaviour
{
    private GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        // Check height level
        if (player.transform.position.y < -2)
        {
            Debug.Log("DEATH");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
