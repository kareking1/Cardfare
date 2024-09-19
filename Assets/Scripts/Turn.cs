using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn
{
    static GameObject FirstPlayer;
    static GameObject SecondPlayer;
    static GameObject TurnPlayer;
    static GameObject OtherPlayer;
    static Character TurnPlayerScript;
    static Character OtherPlayerScript;
    static bool firstTurn = true;

    public static void MatchStart()
    {
        TurnPlayer = GameObject.Find("Player");
        OtherPlayer = GameObject.Find("Enemy");
        FirstPlayer = GameObject.Find("Player");
        SecondPlayer = GameObject.Find("Enemy");
        TurnPlayerScript = TurnPlayer.GetComponent<Character>();
        OtherPlayerScript = OtherPlayer.GetComponent<Character>();

        for (int i = 0; i < 8; i++)
        {
            TurnPlayerScript.PlayerDeck.GetComponent<Deck>().DrawCard();
            OtherPlayerScript.PlayerDeck.GetComponent<Deck>().DrawCard();
        }
    }

    public static void SwitchTurnPlayer()
    {
        if (TurnPlayer.name.Equals("Player"))
        {
            TurnPlayer = SecondPlayer;
            OtherPlayer = FirstPlayer;
            TurnPlayerScript = TurnPlayer.GetComponent<Character>();
            OtherPlayerScript = OtherPlayer.GetComponent<Character>();
        }
        else
        {
            TurnPlayer = FirstPlayer;
            OtherPlayer = SecondPlayer;
            TurnPlayerScript = TurnPlayer.GetComponent<Character>();
            OtherPlayerScript = OtherPlayer.GetComponent<Character>();
        }
    }

    public static void StartTurn()
    {
        if (firstTurn == false)
        {
            TurnPlayerScript.PlayerDeck.GetComponent<Deck>().DrawCard();
            TurnPlayerScript.GenerateResources();
        }
        OtherPlayerScript.SetIfCardsCanBePlayedBasedOnTurnOrPhase(false);
        TurnPlayerScript.SetIfCardsCanBePlayedBasedOnTurnOrPhase(false);
        firstTurn = false;
    }

    public static void PlayPhase()
    {
        TurnPlayerScript.SetIfCardsCanBePlayedBasedOnTurnOrPhase(true);
    }

    public static void EndTurn() {
        SwitchTurnPlayer();
        StartTurn();
        PlayPhase();
    }
}
