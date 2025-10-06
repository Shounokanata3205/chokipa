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
        Back;

    public void MenuTagButton()
    {
        Menu.SetActive(true);
        MenuTag.SetActive(false);
    }

    public void TouchButton()
    {
        TouchMenu.SetActive(true);
        Back.SetActive(true);
        Menu.SetActive(false);
    }

    public void SettingButton()
    {
        SettingMenu.SetActive(true);
        Back.SetActive(true);
        Menu.SetActive(false);
    }

    public void BackButton()
    {
        Menu.SetActive(true);
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
