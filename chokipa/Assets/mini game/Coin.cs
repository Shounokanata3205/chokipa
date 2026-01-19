using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Controls;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{

    public static int CoinPos;
    public static float[] pos = { 2.2f, 0.4f, -1.5f };

    public void Start()
    {
        CoinPos = Random.Range(0, 3);
    }

    Vector2 tmp;
    public float speed;
    float position = CreateCoin.pos[CreateCoin.CoinPos];

    public void Update()
    {
        tmp = transform.position;
        transform.position = new Vector2(tmp.x - speed, pos[CoinPos]);
        //transform.position = new Vector2(tmp.x - speed, tmp.y = position);
    }
}
