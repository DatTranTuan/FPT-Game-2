using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    [SerializeField] private GameObject boarPrefab;
    [SerializeField] private GameObject plantPrefab;

    [SerializeField] private Transform botContain;

    public List<GameObject> listGround; //Mảng các block bản đồ
    public List<GameObject> listCoin; //Mảng các block bản đồ

    [SerializeField] private Transform coinParent;

    public Transform player;

    public float rangeToDestroyObject = 60f; //Khoảng cách để tạo sẵn map và hủy

    public List<GameObject> listGroundOld; //Mảng chứa các block map được tạo ra
    [SerializeField] private List<GameObject> listCoinOld;

    public GameObject lastGround;

    Vector3 endPos; //Vi tri cuoi cung
    Vector3 nextPos; //Vi tri tiep theo
    Vector3 nextCoinPos; //Vi tri tiep theo


    int groundLen;
    int groundHeight;

    // Start is called before the first frame update
    void Start()
    {
        endPos = new Vector3(18.0f, -2.0f, 0.0f);

        generateBlockMap();
        //GenerateCoin();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(player.position, endPos) < rangeToDestroyObject)
        {
            //Invoke(nameof(DestroyLastGround), 3f);
            generateBlockMap();
            //GenerateCoin();
        }

        GameObject getOneGround = listGroundOld.FirstOrDefault();
        if (getOneGround != null && Vector2.Distance(player.position, getOneGround.transform.position) > rangeToDestroyObject)
        {
            listGroundOld.Remove(getOneGround);
            Destroy(getOneGround);
        }

        GameObject getFirstCoinGround = listCoinOld.FirstOrDefault();
        if (getFirstCoinGround != null && Vector2.Distance(player.position, getFirstCoinGround.transform.position) > rangeToDestroyObject)
        {
            listGroundOld.Remove(getFirstCoinGround);
            Destroy(getFirstCoinGround);
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
            float khoangCach = Random.Range(2f, 5f); //Khoảng cách ngẫu nhiên giữa các block
            nextPos = new Vector3(endPos.x + khoangCach, -2f, 0f);

            //Tạo số nguyên ngẫu nhiên trong khoảng từ a-b, không bao gồm b
            int groundID = Random.Range(0, listGround.Count);

            //Tạo ra block bản đồ ngẫu nhiên
            GameObject newGround = Instantiate(listGround[groundID], nextPos, Quaternion.identity, transform);

            listGroundOld.Add(newGround); //THêm miếng đất vừa tạo vào mảng

            switch (groundID)
            {
                case 0: 
                    groundLen = 2;
                    groundHeight = 3;
                    break;
                case 1: 
                    groundLen = 3;
                    groundHeight = 2;
                    break;
                    //case 2: groundLen = 4; break;
                    //case 3: groundLen = 6; break;
                    //case 4: groundLen = 8; break;
            }

            float random = Random.Range(0, 1f);
            if (random <= 0.3f)
            {
                Instantiate(plantPrefab, new Vector3(nextPos.x + 1, nextPos.y + groundHeight, 0), Quaternion.identity, botContain);
            }
            else if (random >0.7f)
            {
                Instantiate(boarPrefab, new Vector3(nextPos.x + 1, nextPos.y + groundHeight, 0), Quaternion.identity, botContain);
            }

            endPos = new Vector3(nextPos.x + groundLen, -2f, 0f);
        }
    }

    public void GenerateCoin()
    {
        for (int i = 0; i < 2; i++)
        {
            float distance = Random.Range(2f, 4f); //Khoảng cách ngẫu nhiên giữa các coin
            nextCoinPos += new Vector3(distance, 0f, 0f); // Di chuyển nextPos sang phải

            //Tạo số nguyên ngẫu nhiên trong khoảng từ a-b, không bao gồm b
            int coinID = Random.Range(0, listCoin.Count);

            // Tính toán giá trị y dựa trên giá trị x (nextPos.x) theo đường cong y = sin(x)
            float y = Mathf.Sin(nextCoinPos.x);

            //Tạo ra coin tại vị trí mới với giá trị y theo đường cong y = sin(x)
            GameObject newCoin = Instantiate(listCoin[coinID], new Vector3(nextCoinPos.x, y, nextPos.z), Quaternion.identity, coinParent);

            // Di chuyển coin sang phải một đơn vị
            newCoin.transform.position += new Vector3(1, 0, 0);

            listCoinOld.Add(newCoin);

            switch (coinID)
            {
                case 0: groundLen = 2; break;
                //case 1: groundLen = 3; break;
            }

            endPos = new Vector3(nextCoinPos.x + groundLen, -2f, 0f);
        }
    }

}
