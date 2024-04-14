using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private GameObject exploe;

    private GameObject explo;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            Destroy(gameObject);
            explo = Instantiate(exploe, transform.position, Quaternion.identity);
            Destroy(explo, 2f);
        }
    }
}
