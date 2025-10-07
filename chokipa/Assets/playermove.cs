using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 100.0f;

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float moveY = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        transform.position = new Vector2(
        //移動範囲を制限する
        Mathf.Clamp(transform.position.x + moveX, 30.0f, 300.0f),
        Mathf.Clamp(transform.position.y + moveY, 10.0f, 550.0f)  
        );
    }
}