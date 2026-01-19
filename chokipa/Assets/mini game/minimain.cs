using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mini : MonoBehaviour
{
    Vector2 tmp;
    float[] pos = { 3.2f, 1.8f, 0.4f, -1f };
    int NowPos;
    public GameObject UPButton,
        DownButton,
        fin,
        TitleButton;

    public float Span = 30.0f; //終了時間

    private float time = 0; //経過時間

    public static int GameTime = 0;

    void Start()
    {
        Vector2 tmp = transform.position;
        NowPos = 2;
    }

    public void UP()
    {
        if (NowPos > 0)
        {
            Position(-1);
        }
    }

    public void Down()
    {
        if (NowPos < 3)
        {
            Position(1);
        }
    }

    public void Position(int line)
    {
        NowPos = NowPos + line;
        transform.position = new Vector3(tmp.x = 1.66f, tmp.y = pos[NowPos], -3.0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //コインオブジェクトの消滅,コイン加算
        if (collision.gameObject.CompareTag("Coin"))
        {
            main.Coin += 1;
            Destroy(collision.gameObject);
        }
    }

    void Update()
    {
        this.time += Time.deltaTime; //時間をカウントする

        //終了時間を経過したら
        if (this.time >= this.Span)
        {
            GameTime = 1;
            fin.SetActive(true);
        }
    }
}
