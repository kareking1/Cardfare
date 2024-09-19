using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CardPlay : MonoBehaviour
{
    bool isPlayable = true;
    bool _isCorrectTurnAndPhase = false;
    GameObject startParent;
    GameObject Player = null;
    GameObject Enemy = null;
    GameObject card = null;
    ICard cardScript = null;
    GameObject subMenu = null;
    GameObject hand = null;

    public bool ISCORRECTTURNANDPHASE
    {
        get { return _isCorrectTurnAndPhase; }

        set { _isCorrectTurnAndPhase = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        hand = transform.parent.gameObject;
        Player = GameObject.Find("Enemy");
        Enemy = GameObject.Find("Player");
        if (hand.name.Equals("PlayerHand"))
        {
            Player = GameObject.Find("Player");
            Enemy = GameObject.Find("Enemy");
        }
        card = gameObject;
        cardScript = GetComponent<ICard>();
    }

    private void Update()
    {
        isPlayable = ISCORRECTTURNANDPHASE == true && !hand.name.Equals($"{Player.name}DeadPile");
    }

    public void ToggleMenu()
    {
        if (Player.name.Equals("Enemy")) return;
        if (subMenu != null)
        {
            Destroy(subMenu);
            Player.GetComponent<Character>().SubMenuOpen = false;
            return;
        }
        if (isPlayable == false) return;
        Player.GetComponent<Character>().SubMenuOpen = true;

        if (TurnUtilities.CheckIfCharHasCosts(Player, cardScript) == false && Player.GetComponent<Character>().HasSacrificed == false)
        {
            CreateSacrificeOnlySubMenu();
            return;
        }
        if (TurnUtilities.CheckIfCharHasCosts(Player, cardScript) == true) CreateNormalSubmenu();
    }

    public void CreateNormalSubmenu()
    {
        GameObject subMenuObj = PrefabUtility.LoadPrefabContents("Assets/Resources/CardPlaySubMenu.prefab");
        subMenu = Instantiate(subMenuObj, new Vector2(0, 0), Quaternion.identity);
        PrepareSubMenuTransform();
        PrefabUtility.UnloadPrefabContents(subMenuObj);
    }

    public void CreateSacrificeOnlySubMenu()
    {
        GameObject subMenuObj = PrefabUtility.LoadPrefabContents("Assets/Resources/CardPlaySubMenuSacrificeOnly.prefab");
        subMenu = Instantiate(subMenuObj, new Vector2(0, 0), Quaternion.identity);
        PrepareSubMenuTransform();
        PrefabUtility.UnloadPrefabContents(subMenuObj);
    }

    public void PrepareSubMenuTransform()
    {
        const float anchorMiddleCenterArgs = 1 / 2;
        subMenu.GetComponent<RectTransform>().anchorMin = new Vector2(anchorMiddleCenterArgs, anchorMiddleCenterArgs);
        subMenu.GetComponent<RectTransform>().anchorMax = new Vector2(anchorMiddleCenterArgs, anchorMiddleCenterArgs);
        subMenu.GetComponent<RectTransform>().sizeDelta = new Vector2(110, 34);
        subMenu.transform.SetParent(GameObject.Find("Main Canvas").transform, false);
        subMenu.transform.SetPositionAndRotation(new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y), Quaternion.identity);
        subMenu.transform.Translate(Constants.SUB_MENU_TRANSLATE_VECTOR);
        CardPlaySubMenu subMenuScript = subMenu.GetComponent<CardPlaySubMenu>();
        subMenuScript.Player = Player;
        subMenuScript.Enemy = Enemy;
        subMenuScript.linkedCard = card;
        subMenuScript.linkedCardScript = cardScript;
    }

    public void CloseMenu() { if (subMenu != null) Destroy(subMenu); }
}
