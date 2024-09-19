using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class CardVisuals : MonoBehaviour
{
    protected ICard card;
    CardPlay cardPlay;
    GameObject cardOwner = null;
    GameObject parent = null;
    //bool isPlayed = false;
    GameObject playableGraphic = null;

    void Start()
    {
        card = GetComponent<ICard>();
        cardPlay = GetComponent<CardPlay>();
        parent = transform.parent.gameObject;
        cardOwner = GameObject.Find("Enemy");
        if (parent.name.Equals("PlayerHand")) cardOwner = GameObject.Find("Player");
        playableGraphic = new GameObject();
        playableGraphic.name = "Test Graphic";
        playableGraphic.transform.SetParent(transform);
        playableGraphic.AddComponent<Image>();
        playableGraphic.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/PlayableCard");
        playableGraphic.transform.SetLocalPositionAndRotation(new Vector2(0, 0), Quaternion.identity);
        playableGraphic.GetComponent<RectTransform>().sizeDelta = new Vector2(Constants.CARD_GRAPHIC_WIDTH, Constants.CARD_GRAPHIC_HEIGHT);
    }

    void Update()
    {
        parent = transform.parent.gameObject;
        if (parent.name.Equals("PlayerDeadPile") || parent.name.Equals("EnemyDeadPile"))
        {
            //isPlayed = true;
            playableGraphic.GetComponent<Image>().enabled = false;
            return;
        }
        //isPlayed = false;
        //Bit of a long if condition to avoid lots of indentation...
        if (parent.name.Equals("EnemyHand") || (TurnUtilities.CheckIfCharHasCosts(cardOwner, card) == false && cardOwner.GetComponent<Character>().HasSacrificed == true) || cardPlay.ISCORRECTTURNANDPHASE == false)
        {
            playableGraphic.GetComponent<Image>().enabled = false;
            return;
        }
        playableGraphic.GetComponent<Image>().enabled = true;
    }

    public void AddBlockPanelCard()
    {
        GameObject blockPanelObject = PrefabUtility.LoadPrefabContents("Assets/Resources/CardBlockPanel.prefab");
        GameObject blockPanel = Instantiate(blockPanelObject, new Vector2(0, 0), Quaternion.identity);
        blockPanel.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = $"BLK: {this.card.BlockValue}";
        blockPanel.transform.SetParent(transform);
        blockPanel.GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 0.5f);
        blockPanel.GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 0.5f);
        blockPanel.GetComponent<RectTransform>().sizeDelta = new Vector2(90, 26);
        blockPanel.transform.SetLocalPositionAndRotation(new Vector2(0, Constants.CARD_HEIGHT / -1.8f), Quaternion.identity);
        PrefabUtility.UnloadPrefabContents(blockPanelObject);
    }
}
