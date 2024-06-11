using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    private Scene _scene;

    private void Awake()
    {
        _scene = SceneManager.GetActiveScene();
    }

    public void Play()
    {
        SceneManager.LoadScene(_scene.buildIndex + 1);
    }

    public void Credits()
    {
        SceneManager.LoadScene(_scene.buildIndex - 1);
    }

    public void Quit()
    {
        Application.Quit();
    }

}
