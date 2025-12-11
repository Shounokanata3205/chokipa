using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Controls;
using UnityEngine.UI;

public class CreateCoin : MonoBehaviour
{
    public GameObject coin;
    public static int CoinPos;
    public static float[] pos = { 2.2f, 0.4f, -1.5f };

    private float Time; // 経過時間を格納する変数

    public void Update()
    {
        Time = UnityEngine.Time.time; // 経過時間を格納
        if (Time >= 1.0f)
        {
            Time -= 1.0f;
            for (int x = 0; x == 0; x++)
            {
                Debug.Log(Time);
                CoinPos = Random.Range(0, 3);
                coin = Instantiate(coin) as GameObject;
                transform.position = new Vector2(9.5f, pos[CoinPos]);
            }
        }
    }
}
