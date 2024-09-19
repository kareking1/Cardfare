using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public void CloseAllCardSubMenus()
    {
        foreach(CardPlay child in GetComponentsInChildren<CardPlay>())
        {
            child.CloseMenu();
        }
    }
}
