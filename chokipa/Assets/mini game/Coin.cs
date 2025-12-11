using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Controls;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    Vector2 tmp;
    public float speed;
    float position = CreateCoin.pos[CreateCoin.CoinPos];
    public void Update()
    {
        tmp = transform.position;
        transform.position = new Vector2(tmp.x - speed, tmp.y = position);
    }
}
