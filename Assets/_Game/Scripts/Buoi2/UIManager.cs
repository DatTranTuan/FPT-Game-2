using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private TextMeshProUGUI coinText;
    [SerializeField] private TextMeshProUGUI highScoreText;

    [SerializeField] private GameObject homePanel;
    [SerializeField] private GameObject playPanel;
    [SerializeField] private GameObject losingPanel;

    [SerializeField] private Button playAgainBtn;
    [SerializeField] private Button playBtn;

    private int coin;

    public int Coin { get => coin; set => coin = value; }
    public GameObject LosingPanel { get => losingPanel; set => losingPanel = value; }

    private void Start()
    {
        Time.timeScale = 1f;
        //playAgainBtn.onClick.AddListener(OnClickPlayBtn);
        highScoreText.text = "Score: " + PlayerPrefs.GetInt("HighScore",0).ToString();
    }

    private void Update()
    {
        coinText.text = Coin.ToString();
    }

    public void CheckPref()
    {
        if (coin > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", coin);
            highScoreText.text = "Score: " + coin.ToString();
        }
    }

    public void OnClickPlayBtn()
    {
        homePanel.SetActive(false);
        playPanel.SetActive(true);
        Time.timeScale = 1f;
    }

    public void LoadScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}
