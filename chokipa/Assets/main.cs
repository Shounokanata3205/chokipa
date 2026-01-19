using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class main : MonoBehaviour
{
    public GameObject MenuTag,
        Menu,
        Touch,
        Setting,
        TouchMenu,
        Caress,
        SettingMenu,
        Back,
        Close;

    [SerializeField]
    TextMeshProUGUI Time,
        Money;
    public static int Coin = 0;
    int BackMenu = 0;
    int hour = System.DateTime.Now.Hour;
    int minute = System.DateTime.Now.Minute;

    public void Update()
    {
        int hour = System.DateTime.Now.Hour;
        int minute = System.DateTime.Now.Minute;
        if (minute <= 9)
        {
            Time.text = hour + ":0" + minute;
        }
        Time.text = hour + ":" + minute;
        Money.SetText("{0}", Coin);
    }

    public void MenuTagButton()
    {
        Menu.SetActive(true);
        Close.SetActive(true);
        MenuTag.SetActive(false);
    }

    public void TouchButton()
    {
        Menu.SetActive(false);
        Close.SetActive(false);
        TouchMenu.SetActive(true);
        Back.SetActive(true);
        BackMenu = 1;
    }

    public void SettingButton()
    {
        Menu.SetActive(false);
        Close.SetActive(false);
        SettingMenu.SetActive(true);
        Back.SetActive(true);
        BackMenu = 2;
    }

    public void BackButton()
    {
        if (BackMenu == 1)
        {
            TouchMenu.SetActive(false);
            Back.SetActive(false);
            Close.SetActive(false);
            Menu.SetActive(true);
            Close.SetActive(true);
        }
        else if (BackMenu == 2)
        {
            SettingMenu.SetActive(false);
            Back.SetActive(false);
            Close.SetActive(false);
            Menu.SetActive(true);
            Close.SetActive(true);
        }
    }

    public void CloseButton()
    {
        Menu.SetActive(false);
        Close.SetActive(false);
        MenuTag.SetActive(true);
    }
}
