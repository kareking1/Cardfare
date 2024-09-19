using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SacrificeButtonSubMenu : MonoBehaviour
{
    public void OnClick()
    {
        transform.parent.gameObject.GetComponent<CardPlaySubMenu>().SacrificeCard();
    }
}
