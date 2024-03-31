using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    private void Start()
    {
        Destroy(gameObject,1.5f);
    }

    private void Update()
    {
        rb.velocity = new Vector2(10f, rb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == CacheString.ENEMY_LAYER)
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
}
