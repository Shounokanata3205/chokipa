using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mini : MonoBehaviour
{
    Vector2 tmp;
    float[] pos = { 2.2f, 0.4f, -1.5f };
    int NowPos;
    public GameObject UPButton,
        DownButton;

    void Start()
    {
        Vector2 tmp = transform.position;
        NowPos = 1;
    }

    public void UP()
    {
        if (NowPos >= 1)
        {
            Position(-1);
        }
    }

    public void Down()
    {
        if (NowPos <= 1)
        {
            Position(1);
        }
    }

    public void Position(int line)
    {
        NowPos = NowPos + line;
        transform.position = new Vector2(tmp.x = -6, tmp.y = pos[NowPos]);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //コインオブジェクトの消滅
        if (collision.gameObject.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
        }
    }
}
