using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTurnButtonManager : MonoBehaviour
{
    public void OnClick()
    {
        Turn.EndTurn();
    }
}
