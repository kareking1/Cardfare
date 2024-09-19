using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnUtilities 
{
    public static bool CheckIfCharHasCosts(GameObject CardOwner, ICard card)
    {
        Character charShortcut = CardOwner.GetComponent<Character>();
        bool hasCosts = true;
        if (charShortcut.Population < card.Costs[0]) hasCosts = false;
        if (charShortcut.Metals < card.Costs[1]) hasCosts = false;
        if (charShortcut.Crystals < card.Costs[2]) hasCosts = false;
        if (charShortcut.PopGen < card.Costs[3]) hasCosts = false;
        if (charShortcut.MetGen < card.Costs[4]) hasCosts = false;
        if (charShortcut.CryGen < card.Costs[5]) hasCosts = false;
        //Hero isn't implemented yet for Costs[6]
        if (charShortcut.HP <= card.Costs[7]) hasCosts = false;

        return hasCosts;
    }

    public static void PayCardCosts(GameObject CardOwner, ICard card)
    {
        Character charShortcut = CardOwner.GetComponent<Character>();
        charShortcut.Population -= card.Costs[0];
        charShortcut.Metals -= card.Costs[1];
        charShortcut.Crystals -= card.Costs[2];
        charShortcut.PopGen -= card.Costs[3];
        charShortcut.MetGen -= card.Costs[4];
        charShortcut.CryGen -= card.Costs[5];
        //Hero isn't implemented yet for Costs[6]
        charShortcut.HP -= card.Costs[7];
    }

    public static void Build(GameObject CardOwner, int amount)
    {
        Character charScript = CardOwner.GetComponent<Character>();
        charScript.HP += amount;
    }

    public static void Sacrifice(GameObject CardOwner, ICard card)
    {
        Character charShortcut = CardOwner.GetComponent<Character>();
        charShortcut.Population += card.Costs[0]/2;
        charShortcut.Metals += card.Costs[1]/2;
        charShortcut.Crystals += card.Costs[2]/2;
    }
}
