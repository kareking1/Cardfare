using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButtonSubMenu : MonoBehaviour
{
    public void OnClick()
    {
        transform.parent.gameObject.GetComponent<CardPlaySubMenu>().PlayCard();
    }
}
