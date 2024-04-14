using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private Slider slider;

    [SerializeField] private GameObject bombPrefab;
    private GameObject bombSpawn;

    private int heal;
    private bool isOK = true;

    public int Heal { get => heal; set => heal = value; }
    public Slider Slider { get => slider; set => slider = value; }

    private void Awake()
    {
        heal = 5;
    }

    private void Update()
    {
        if (heal == 0)
        {
            OnPlayerDeath();
        }

        if (isOK)
        {
            StartCoroutine(BombSpawn());
        }
    }

    public void OnPlayerDeath()
    {
        Time.timeScale = 0f;
        UIManager.Instance.LosingPanel.gameObject.SetActive(true);
    }

    public void GetShot(float currentHeath, float maxHeath)
    {
        Slider.value = currentHeath / maxHeath;
    }

    public IEnumerator BombSpawn()
    {
        isOK = false;
        yield return new WaitForSeconds(3f);
        SpawnBomb();
        isOK = true;
    }

    public void SpawnBomb()
    {
        float random = Random.Range(-12f, 11f);
        bombSpawn = Instantiate(bombPrefab, new Vector3(random, 10f, 0f), Quaternion.identity);
    }
}
