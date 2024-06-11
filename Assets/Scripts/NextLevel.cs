using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    private Scene _scene;
    public bool playerIsClose;

    private void Awake()
    {
        _scene = SceneManager.GetActiveScene();
        if (Input.GetKeyDown(KeyCode.E) && playerIsClose && Score.totalScore == 5)
        {
            StartLevel();
        }
    }

    public void StartLevel()
    {
        SceneManager.LoadScene(_scene.buildIndex + 1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerIsClose = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerIsClose = false;
        }
    }
}
