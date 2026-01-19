using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Controls;
using UnityEngine.UI;

public class CreateCoin : MonoBehaviour
{
    public GameObject coin;
    public static float[] pos = { 3.4f, 2.1f, 0.56f, -0.75f };
    public float Span = 1.0f; //繰り返す間隔
    private float time = 0; //経過時間
    float AllTime = 0;

    void Update()
    {
        this.time += Time.deltaTime; //時間をカウントする
        AllTime += Time.deltaTime;

        if (AllTime <= 30)
        {
            //経過時間が繰り返す間隔を経過したら
            if (this.time >= this.Span)
            {
                this.time = 0;
                int y = Random.Range(0, 4);
                GameObject go = Instantiate(coin);
                go.transform.position = new Vector3(9.5f, pos[y], -3.0f);
            }
        }
    }
}
