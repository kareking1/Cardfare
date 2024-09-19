using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPlacementManager : MonoBehaviour
{
    public GameObject Player;
    Character playerScript;
    public GameObject[] permanentZones;
    public GameObject[] nonPermanentZones;

    // Start is called before the first frame update
    void Start()
    {
        playerScript = Player.GetComponent<Character>();
    }

    public void PlacePermanentCard(GameObject card)
    {
        foreach (GameObject zone in permanentZones)
        {
            if (zone.transform.childCount != 1)
            {
                card.transform.SetParent(zone.transform, false);
                PrepareCardTransform(card);
                return;
            }
        }
    }

    public void PlaceNonPermanentCard(GameObject card)
    {
        foreach (GameObject zone in nonPermanentZones)
        {
            if (zone.transform.childCount != 1)
            {
                card.transform.SetParent(zone.transform, false);
                PrepareCardTransform(card);
                return;
            }
        }
    }

    public void SendCardToDeadPile(string zoneType, int index)
    {

    }

    public bool AllZonesOccupied(string zoneType)
    {
        if (zoneType.Equals("Permanent"))
        {
            foreach (GameObject zone in permanentZones)
            {
                if (zone.transform.childCount != 1)
                {
                    return false;
                }
            }
            return true;
        }
        foreach (GameObject zone in nonPermanentZones)
        {
            if (zone.transform.childCount != 1)
            {
                return false;
            }
        }
        return true;
    }

    public void PrepareCardTransform(GameObject card)
    {
        card.GetComponent<RectTransform>().sizeDelta = new Vector2(Constants.CARD_WIDTH, Constants.CARD_HEIGHT);
        card.GetComponent<RectTransform>().localScale = new Vector2(1, 1);
        card.transform.SetLocalPositionAndRotation(new Vector2(0, 0), Quaternion.identity);
    }

    public void CloseAllCardSubMenus()
    {
        foreach (GameObject zone in permanentZones)
        {
            if (zone.transform.childCount == 1)
            {
                zone.GetComponentInChildren<CardPlay>().CloseMenu();
            }
        }
        foreach (GameObject zone in nonPermanentZones)
        {
            if (zone.transform.childCount == 1)
            {
                zone.GetComponentInChildren<CardPlay>().CloseMenu();
            }
        }
    }
}
