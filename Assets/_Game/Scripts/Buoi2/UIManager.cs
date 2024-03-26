using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private TextMeshProUGUI coinText;

    private int coin;

    public int Coin { get => coin; set => coin = value; }

    private void Update()
    {
        coinText.text = Coin.ToString();
    }
}
