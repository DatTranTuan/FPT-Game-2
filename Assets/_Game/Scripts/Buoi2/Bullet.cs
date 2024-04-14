using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    private void Start()
    {
        rb.velocity = new Vector2(-5f, 10f);
        Destroy(gameObject, 3f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == CacheString.PLAYER_LAYER)
        {
            GameManager.Instance.Heal--;
            GameManager.Instance.GetShot(GameManager.Instance.Heal, 5);
            Destroy(gameObject);
        }
    }
}
