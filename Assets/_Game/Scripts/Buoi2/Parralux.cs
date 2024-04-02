using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parralux : MonoBehaviour
{
    private Material material;

    [SerializeField] private float distance;

    [Range(0f, 0.5f)]
    [SerializeField] private float speed = 0.2f;

    private void Start()
    {
        material = GetComponent<Renderer>().material;
    }

    private void Update()
    {
        distance += Time.deltaTime * speed;
        material.SetTextureOffset("_MainTex", Vector2.left* distance);
    }
}
