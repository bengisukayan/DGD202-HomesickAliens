using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    public float speed;
    private Rigidbody2D _rigidBody;
    private Transform _currentPoint;
    private SpriteRenderer _spriteRenderer;

    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _currentPoint = pointB.transform;
        _spriteRenderer = GetComponent<SpriteRenderer>();

    }

    void Update()
    {
        Vector2 point = _currentPoint.position - transform.position;
        if(_currentPoint == pointB.transform)
        {
            _rigidBody.velocity = new Vector2(speed, 0);
            _spriteRenderer.flipX = true;
        } else
        {
            _rigidBody.velocity = new Vector2(-speed, 0);
            _spriteRenderer.flipX = false;
        }


        if(Vector2.Distance(transform.position, _currentPoint.position) < 0.5f && _currentPoint == pointB.transform)
        {
            _currentPoint = pointA.transform;
        }
        if (Vector2.Distance(transform.position, _currentPoint.position) < 0.5f && _currentPoint == pointA.transform)
        {
            _currentPoint = pointB.transform;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(pointA.transform.position, 0.5f);
        Gizmos.DrawWireSphere(pointB.transform.position, 0.5f);
    }
}
