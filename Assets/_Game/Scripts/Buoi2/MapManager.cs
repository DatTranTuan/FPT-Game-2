﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public List<GameObject> listGround; //Mảng các block bản đồ
    public Transform player;
    public float rangeToDestroyObject = 60f; //Khoảng cách để tạo sẵn map và hủy

    public List<GameObject> listGroundOld; //Mảng chứa các block map được tạo ra

    public GameObject lastGround;

    Vector3 endPos; //Vi tri cuoi cung
    Vector3 nextPos; //Vi tri tiep theo


    int groundLen;

    // Start is called before the first frame update
    void Start()
    {
        endPos = new Vector3(18.0f, -2.0f, 0.0f);

        generateBlockMap();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(player.position, endPos) < rangeToDestroyObject)
        {
            //Invoke(nameof(DestroyLastGround), 3f);
            generateBlockMap();
        }

        GameObject getOneGround = listGroundOld.FirstOrDefault();
        if (getOneGround != null && Vector2.Distance(player.position, getOneGround.transform.position) > rangeToDestroyObject)
        {
            listGroundOld.Remove(getOneGround);
            Destroy(getOneGround);
        }
    }

    public void DestroyLastGround()
    {
        Destroy(lastGround);
    }

    void generateBlockMap()
    {
        for (int i = 0; i < 1; i++)
        {
            float khoangCach = Random.Range(2f, 4f); //Khoảng cách ngẫu nhiên giữa các block
            nextPos = new Vector3(endPos.x + khoangCach, -2f, 0f);

            //Tạo số nguyên ngẫu nhiên trong khoảng từ a-b, không bao gồm b
            int groundID = Random.Range(0, listGround.Count);

            //Tạo ra block bản đồ ngẫu nhiên
            GameObject newGround = Instantiate(listGround[groundID], nextPos, Quaternion.identity, transform);
            listGroundOld.Add(newGround); //THêm miếng đất vừa tạo vào mảng

            switch (groundID)
            {
                case 0: groundLen = 2; break;
                case 1: groundLen = 3; break;
                //case 2: groundLen = 4; break;
                //case 3: groundLen = 6; break;
                //case 4: groundLen = 8; break;
            }

            endPos = new Vector3(nextPos.x + groundLen, -2f, 0f);
        }
    }
}