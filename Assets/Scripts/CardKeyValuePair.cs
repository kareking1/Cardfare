using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardKeyValuePair
{
    public ICard card;
    public int amount;

    public CardKeyValuePair(ICard givenCard, int givenAmount)
    {
        card = givenCard;
        amount = givenAmount;
    }
}
