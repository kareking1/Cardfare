using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VillageHPVisuals : MonoBehaviour
{
    public GameObject linkedCharacter;
    Character linkedCharacterScript;
    //To be put in constants
    Color rbgBrownVillage = new Color(0.549f, 0.3215f, 0.1764f);
    Color rbgGreyCastle = new Color(0.3803f, 0.3803f, 0.3803f);

    private void Start()
    {
        linkedCharacterScript = linkedCharacter.GetComponent<Character>();
    }

    private void Update()
    {
        if (linkedCharacterScript.HP >= 100 && linkedCharacterScript.HasCastle == false)
        {
            linkedCharacterScript.HP -= 80;
            GetComponent<Image>().color = rbgGreyCastle;
            linkedCharacterScript.HasCastle = true;
        }
        if (linkedCharacterScript.HP <= 0 && linkedCharacterScript.HasCastle == true)
        {
            linkedCharacterScript.HP = 40;
            GetComponent<Image>().color = rbgBrownVillage;
            linkedCharacterScript.HasCastle = false;
        }
    }
}
