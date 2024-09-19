using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;
using UnityEngine.UI;

public class Deck : MonoBehaviour
{
    List<CardKeyValuePair> cardsAndCount = new List<CardKeyValuePair>();
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        GameObject militia = GetCardPrefab("Militia");
        GameObject infantry = GetCardPrefab("Infantry");
        GameObject bountiful_harvest = GetCardPrefab("Bountiful Harvest");
        GameObject crystal_deposit = GetCardPrefab("Crystal Deposit");
        GameObject crystal_generator = GetCardPrefab("Crystal Generator");
        GameObject investment_into_the_future = GetCardPrefab("Investment into the Future");
        GameObject metalGeneratorDebug = GetCardPrefab("MetalGeneratorDebug");
        GameObject ore_deposit = GetCardPrefab("Ore Deposit");
        GameObject popGeneratorDebug = GetCardPrefab("PopGeneratorDebug");
        GameObject thunderstrike = GetCardPrefab("Thunderstrike");
        GameObject trebuchet = GetCardPrefab("Trebuchet");
        GameObject carpenter = GetCardPrefab("Carpenters");
        GameObject debugHealEnemy = GetCardPrefab("DebugHealEnemy");
        GameObject yellowBarrier = GetCardPrefab("YellowBarrier");
        GameObject scout = GetCardPrefab("Scout");


        cardsAndCount.Add(new CardKeyValuePair (militia.GetComponent<ICard>(), 1 ));
        cardsAndCount.Add(new CardKeyValuePair (infantry.GetComponent<ICard>(), 1));
        cardsAndCount.Add(new CardKeyValuePair(bountiful_harvest.GetComponent<ICard>(), 1));
        cardsAndCount.Add(new CardKeyValuePair(crystal_deposit.GetComponent<ICard>(), 1));
        cardsAndCount.Add(new CardKeyValuePair(crystal_generator.GetComponent<ICard>(), 1));
        cardsAndCount.Add(new CardKeyValuePair(investment_into_the_future.GetComponent<ICard>(), 1));
        cardsAndCount.Add(new CardKeyValuePair(metalGeneratorDebug.GetComponent<ICard>(), 1));
        cardsAndCount.Add(new CardKeyValuePair(ore_deposit.GetComponent<ICard>(), 1));
        cardsAndCount.Add(new CardKeyValuePair(popGeneratorDebug.GetComponent<ICard>(), 1));
        cardsAndCount.Add(new CardKeyValuePair(thunderstrike.GetComponent<ICard>(), 1));
        cardsAndCount.Add(new CardKeyValuePair(trebuchet.GetComponent<ICard>(), 1));
        //cardsAndCount.Add(new CardKeyValuePair(carpenter.GetComponent<ICard>(), 1));
        //cardsAndCount.Add(new CardKeyValuePair(debugHealEnemy.GetComponent<ICard>(), 5));
        //cardsAndCount.Add(new CardKeyValuePair(yellowBarrier.GetComponent<ICard>(), 6));
        cardsAndCount.Add(new CardKeyValuePair(scout.GetComponent<ICard>(), 8));
    }
    
    public void DrawCard()
    {
        //Maximum is exclusive
        int result = 0;
        if (cardsAndCount.Count != 0) result = UnityEngine.Random.Range(0, cardsAndCount.Count);
        else return;
        CardKeyValuePair retrievedCard = cardsAndCount[result];
        CardKeyValuePair newAmount = new CardKeyValuePair(retrievedCard.card, retrievedCard.amount - 1);
        if (newAmount.amount == 0) cardsAndCount.RemoveAt(result);
        else cardsAndCount[result] = newAmount;
        if (cardsAndCount.Count == 0)
        {
            this.GetComponentInChildren<Image>().enabled = false;
        }
        if (newAmount.card == null) return;
        Player.GetComponent<Character>().AddCard(newAmount.card.CardName);
    }

    GameObject GetCardPrefab(string nameOfCard)
    {
        GameObject cardObject = PrefabUtility.LoadPrefabContents($"Assets/Resources/CardPrefabs/{nameOfCard}.prefab");
        GameObject card = Instantiate(cardObject, new Vector2(0, 0), Quaternion.identity);
        Destroy(card.GetComponent<CardVisuals>());
        Destroy(card.GetComponent<CardPlay>());
        PrefabUtility.UnloadPrefabContents(cardObject);
        return card;
    }
}
