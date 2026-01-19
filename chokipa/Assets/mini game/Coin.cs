using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Controls;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    GameObject player;
    public void Start()
    {
        this.player = GameObject.Find("player");
    }

    public void Update()
    {
        transform.Translate(-0.02f, 0, 0);

        if (transform.position.x < -10.0f)
        {
            Destroy(gameObject);
        }
    }
}
