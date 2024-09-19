using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatInput : MonoBehaviour
{
    public GameObject Chat;
    
    public void AddText()
    {
        string text = GameObject.Find("ChatInputText").GetComponent<TMPro.TextMeshProUGUI>().text;
        GameObject newTextObject = new GameObject();
        newTextObject.AddComponent<TMPro.TextMeshProUGUI>();
        newTextObject.GetComponent<TMPro.TextMeshProUGUI>().text = text;
        newTextObject.GetComponent<TMPro.TextMeshProUGUI>().fontSize = 30;
        newTextObject.transform.SetParent(Chat.transform);
        newTextObject.transform.SetLocalPositionAndRotation(new Vector3(0, 0, 0), Quaternion.identity);
    }
}
