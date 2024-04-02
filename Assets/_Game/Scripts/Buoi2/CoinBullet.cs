using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    private Bot boar;

    private void Start()
    {
        boar = GetComponent<Bot>();
        Destroy(gameObject,1.5f);
    }

    private void Update()
    {
        rb.velocity = new Vector2(12f, rb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Character character = collision.GetComponent<Character>();

        if (collision.gameObject.layer == CacheString.ENEMY_LAYER)
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }

        if (collision.gameObject.layer == CacheString.BOAR_LAYER)
        {
            ((Bot)character).Life--;
            Destroy(this.gameObject);

            if (((Bot)character).Life <= 0)
            {
                ((Bot)character).OnDeath();
            }
        }
    }
}
