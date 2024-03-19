using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buoi_2 : MonoBehaviour
{
    private void OnGUI()
    {
        GUI.Box(new Rect(30, 10, 200, 80), "Main Menu");
        GUI.Button(new Rect(100, 100, 100, 50), "Play Game");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
