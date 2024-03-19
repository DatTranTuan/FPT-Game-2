﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    Transform cam; //Camera chính
    Vector3 camStartPos;
    float distance; //Khoảng cách giữa camera và vị trí bắt đầu. Chính là vị trí hiện tại   

    GameObject[] backgrounds;
    Material[] mat;

    float[] backSpeed;

    float farthestBack = 2f;

    [Range(0.01f, 0.05f)]
    public float parallaxSpeed;

    void Start()
    {
        cam = Camera.main.transform;
        camStartPos = cam.position;

        int backCount = transform.childCount; //Đếm số nền 

        backSpeed = new float[backCount];

        backgrounds = new GameObject[backCount];
        mat = new Material[backCount];

        for (int i = 0; i < backCount; i++)
        {
            backgrounds[i] = transform.GetChild(i).gameObject; //Gán đối tượng ảnh nền
            mat[i] = backgrounds[i].GetComponent<Renderer>().material;
        }
        BackSpeedCalculate(backCount);
    }

    void BackSpeedCalculate(int backCount)
    {
        for (int i = 0; i < backCount; i++) //Tìm nền xa nhất
        {
            if (backgrounds[i].transform.position.z - cam.position.z < farthestBack)
            {
                farthestBack = backgrounds[i].transform.position.z - cam.position.z;
            }
        }

        for (int i = 0; i < backCount; i++) //thiết lập tốc độ cho các nền. Càng xa càng chậm
        {
            backSpeed[i] = 1 - (backgrounds[i].transform.position.z - cam.position.z) / farthestBack;
        }
    }

    private void LateUpdate()
    {
        distance = cam.position.x - camStartPos.x;
        transform.position = new Vector3(cam.position.x, cam.position.y, 0);

        for (int i = 0; i < backgrounds.Length; i++)
        {
            float speed = backSpeed[i] * parallaxSpeed;
            mat[i].SetTextureOffset("_MainTex", new Vector2(distance, 0) * speed);
        }
    }
}
