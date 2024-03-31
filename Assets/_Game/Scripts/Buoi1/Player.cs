using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Player : Character
{
    [SerializeField] private GameObject coinBullet;
    [SerializeField] private Transform shootPos;

    [SerializeField] private GameObject cb;

    public float maxSpeed;
    public float jumHeight;
    Rigidbody2D myBody;
    Animator myAnim;
    bool grounded;
    public LayerMask groundLayer;

    public GameObject Cb { get => cb; set => cb = value; }

    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
    }
    void Update()
    {
        grounded = CheckGrounded();
        float move = Input.GetAxis("Horizontal");

        if (Mathf.Abs(move) > 0.1f)
        {
            ChangeAnim("Run");
        }

        if (Mathf.Abs(move) > 0.1f)
        {
            myBody.velocity = new Vector2(move * maxSpeed, myBody.velocity.y);

            // horizontal > 0 -> tra ve 0, neu horizontal <= 0 -> tra ve 180
            //transform.rotation = Quaternion.Euler(new Vector3(0, move > 0 ? 0 : 180, 0));
            //transform.localScale = new Vector3(horizontal, 1, 1);
        }
        else if (grounded)
        {
            ChangeAnim("Idle");
            myBody.velocity = Vector2.zero;
        }

        if (Input.GetKey(KeyCode.Z))
        {
            if (grounded)
            {
                grounded = false;
                myBody.velocity = new Vector2(myBody.velocity.x, jumHeight);
            }
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            ShootCoin();
        }
    }
    // void OnCollisionEnter2D(Collision2D other)
    // {
    //     if (other.gameObject.tag == "ground")
    //     {
    //         grounded = true;
    //     }
    // }
    private bool CheckGrounded()
    {
        Debug.DrawLine(transform.position, transform.position + Vector3.down * 0.2f, Color.red);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.2f, groundLayer);

        //if (hit.collider != null)
        //{
        //    Debug.Log("inside1");
        //    return true;
        //}
        //else
        //{
        //    Debug.Log("inside2");
        //    return false;
        //}

        return hit.collider != null;
    }

    public void ShootCoin()
    {
        if (UIManager.Instance.Coin > 0)
        {
            Cb =  Instantiate(coinBullet, shootPos);
            UIManager.Instance.Coin--;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == CacheString.COIN_LAYER)
        {
            UIManager.Instance.Coin++;
            Destroy(collision.gameObject);
        }
    }

}