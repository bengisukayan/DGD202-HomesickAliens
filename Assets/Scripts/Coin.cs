using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Coin : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private AudioSource _audio;

    private void Awake()
    {
        _text.text = Score.totalScore.ToString();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _audio.Play();
            Destroy(gameObject);
            Score.totalScore++;
            _text.text = Score.totalScore.ToString();
            
        }
    }
}
