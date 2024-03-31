using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot : Character
{
    [SerializeField] private int _direction; //1 right; -1 left
    [SerializeField] private Rigidbody2D _rb; //Boar
    [SerializeField] private float _speedBoar; //Boar move speed

    void Start()
    {
        _direction = -1;
        _speedBoar = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        _rb.velocity = new Vector3(_speedBoar * _direction, 0, 0);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == CacheString.WALL_LAYER)
        {
            _direction *= -1;
            _rb.gameObject.transform.localScale = new Vector3(_rb.gameObject.transform.localScale.x * -1, 1, 1);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == CacheString.PLAYER_LAYER)
        {
            Time.timeScale = 0f;
        }
    }
}
