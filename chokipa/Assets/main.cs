using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main : MonoBehaviour
{
    public GameObject MenuTag,
        Menu,
        Touch,
        Setting,
        TouchMenu,
        Caress,
        TakeOut,
        SettingMenu,
        Volume,
        Credit,
        Back,
        Close;

    int BackMenu = 0;

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

    public void CaressButton()
    {
        //SettingMenu.SetActive(false);
    }

    public void TakeOutButton()
    {
        //SettingMenu.SetActive(false);
    }

    public void VolumeButton()
    {
        //SettingMenu.SetActive(false);
    }

    public void CreditButton()
    {
        //SettingMenu.SetActive(false);
    }
}
