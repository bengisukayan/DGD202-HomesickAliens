using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelStart : MonoBehaviour
{
    private Scene _scene;

    private void Awake()
    {
        _scene = SceneManager.GetActiveScene();
    }

    public void StartLevel()
    {
        Score.currentMoney = 0;
        SceneManager.LoadScene(_scene.buildIndex + 1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartLevel();
        }
    }
}
