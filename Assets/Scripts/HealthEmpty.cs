using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthEmpty : MonoBehaviour
{
    private void Awake()
    {
        Transform child1 = transform.Find("EmptyHeart1");
        Transform child2 = transform.Find("EmptyHeart2");
        Transform child3 = transform.Find("EmptyHeart3");

        child1.gameObject.SetActive(false);
        child2.gameObject.SetActive(false);
        child3.gameObject.SetActive(false);

        switch (Score.lives)
        {
            case 3:
                break;
            case 2:
                child3.gameObject.SetActive(true);
                break;
            case 1:
                child3.gameObject.SetActive(true);
                child2.gameObject.SetActive(true);
                break;
            default:
                break;
        }
    }
}