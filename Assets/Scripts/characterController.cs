using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour
{
    public float jumpForce = 4.0f;
    public float speed = 1.0f;
    public AudioSource my_audio;
    private float direction;

    private bool _jump;
    private bool _grounded = true;
    private Rigidbody2D _rb2D;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        if (Score.lives != 3)
        {
            my_audio.Play();
        }
    }

    private void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        _rb2D.velocity = new Vector2(speed * direction, _rb2D.velocity.y);
        if (_jump)
        {
            _rb2D.velocity = new Vector2(_rb2D.velocity.x, jumpForce);
            _jump = false;
        }
    }

    private void Update()
    {
        if (_grounded && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
        {
            if (Input.GetKey(KeyCode.A))
            {
                direction = -1.0f;
                _spriteRenderer.flipX = true;
                _animator.SetFloat("speed", 1.0f);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                direction = 1.0f;
                _spriteRenderer.flipX = false;
                _animator.SetFloat("speed", 1.0f);
            }
        }
        else if (_grounded)
        {
            direction = 0.0f;
            _animator.SetFloat("speed", 0.0f);
        }

        if (_grounded && Input.GetKey(KeyCode.W))
        {
            _jump = true;
            _grounded = false;
            _animator.SetTrigger("jump");
            _animator.SetBool("grounded", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("floor"))
        {
            _grounded = true;
            _animator.SetBool("grounded", true);
        }
    }

}
