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
}
