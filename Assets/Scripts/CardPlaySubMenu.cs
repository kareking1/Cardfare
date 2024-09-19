using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPlaySubMenu : MonoBehaviour
{
    public GameObject linkedCard = null;
    public ICard linkedCardScript = null;
    public GameObject Player = null;
    Character playerScript;
    public GameObject Enemy = null;

    private void Start()
    {
        playerScript = Player.GetComponent<Character>();
    }

    public void PlayCard()
    {
        TurnUtilities.PayCardCosts(Player, linkedCardScript);
        if (linkedCardScript.Attack != 0) Battle.InflictBattleDamage(Player, Enemy, linkedCardScript);
        if (linkedCardScript.BuildValue != 0) TurnUtilities.Build(Player, linkedCardScript.BuildValue);
        playerScript.Armor += linkedCardScript.ArmorValue;
        playerScript.MagicBarrier += linkedCardScript.MagicBarrierValue;
        Player.GetComponent<Character>().SubMenuOpen = false;
        playerScript.CardPlacementManager.GetComponent<CardPlacementManager>().PlaceNonPermanentCard(linkedCard);
        if (linkedCardScript.IsPermanent == true)
        {
            playerScript.CardPlacementManager.GetComponent<CardPlacementManager>().PlacePermanentCard(linkedCard);
            if (linkedCardScript.BlockValue != 0) linkedCard.GetComponent<CardVisuals>().AddBlockPanelCard();
            return;
        }
        playerScript.SendToDeadPile(linkedCard);
    }

    public void SacrificeCard()
    {
        if (playerScript.HasSacrificed == true) return;
        playerScript.HasSacrificed = true;

        Player.GetComponent<Character>().SubMenuOpen = false;
        playerScript.SendToDeadPile(linkedCard);
        TurnUtilities.Sacrifice(Player, linkedCardScript);
        Player.GetComponent<Character>().SubMenuOpen = false;
    }
}
