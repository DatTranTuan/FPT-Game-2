using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bot : Character
{
    [SerializeField] private int _direction; //1 right; -1 left
    [SerializeField] private Rigidbody2D _rb; //Boar
    [SerializeField] private float _speedBoar; //Boar move speed

    [SerializeField] private Slider slider;

    private int life = 3;
    private int iCount;

    private bool isMoving;

    public int Life { get => life; set => life = value; }

    void Start()
    {
        iCount = 1;
        isMoving = true;
        _direction = -1;
        _speedBoar = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            _rb.velocity = Vector2.zero;
            isMoving = false;
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            isMoving = true;
        }

        if (isMoving)
        {
            _rb.velocity = new Vector3(_speedBoar * _direction, 0, 0);
        }
    }

    public void OnDeath()
    {
        Destroy(gameObject);
        life = 2;
    }

    public void GetShot(float currentHeath, float maxHeath)
    {
        slider.value = currentHeath / maxHeath;
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
            GameManager.Instance.Heal--;
            GameManager.Instance.GetShot(GameManager.Instance.Heal, 5);
        }
    }
}
