using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    List<ICard> hand = new List<ICard>();
    int _hp = Constants.DEFAULT_PLAYER_VALUES["HP"];
    int _population = Constants.DEFAULT_PLAYER_VALUES["Population"];
    int _metals = Constants.DEFAULT_PLAYER_VALUES["Metals"];
    int _crystals = Constants.DEFAULT_PLAYER_VALUES["Crystals"];
    int _popGen = Constants.DEFAULT_PLAYER_VALUES["PopulationGen"];
    int _metGen = Constants.DEFAULT_PLAYER_VALUES["MetalsGen"];
    int _cryGen = Constants.DEFAULT_PLAYER_VALUES["CrystalsGen"];
    int _armor = Constants.DEFAULT_PLAYER_VALUES["Armor"];
    int _magicBarrier = Constants.DEFAULT_PLAYER_VALUES["Magic Barrier"];
    bool _subMenuOpen = false;
    bool _hasCastle = false;
    bool _hasSacrificed = false;
    public GameObject PlayerHand;
    public GameObject EnemyHand;
    public GameObject PlayerPermanents;
    public GameObject PlayerNPermanents;
    public GameObject Health;
    public GameObject PopulationDisplay;
    public GameObject MetalsDisplay;
    public GameObject CrystalsDisplay;
    public GameObject GeneratorsDisplay;
    public GameObject ArmorDisplay;
    public GameObject MagicBarrierDisplay;
    public GameObject PlayerDeck;
    public GameObject PlayerDeadPile;
    public GameObject CardPlacementManager;

    public int Armor
    {
        get { return _armor; }
        set
        {
            if (value < 0)
            {
                _armor = 0;
            }
            _armor = value;
        }
    }

    public int MagicBarrier
    {
        get { return _magicBarrier; }
        set
        {
            if (value < 0)
            {
                _magicBarrier = 0;
            }
            _magicBarrier = value;
        }
    }

    public bool SubMenuOpen
    {
        get { return _subMenuOpen; }
        set
        {
            if (_subMenuOpen == true)
            {
                PlayerHand.GetComponent<Hand>().CloseAllCardSubMenus();
                CardPlacementManager.GetComponent<CardPlacementManager>().CloseAllCardSubMenus();
            }
            _subMenuOpen = value;
        }
    }

    public bool HasCastle
    {
        get { return _hasCastle; }
        set
        {
            _hasCastle = value;
        }
    }

    public bool HasSacrificed
    {
        get { return _hasSacrificed; }
        set
        {
            _hasSacrificed = value;
        }
    }

    public int HP {
        get { return _hp; }
        set {
            if (value <= 0 && HasCastle == false)
            {
                _hp = 0;
                DeclareDefeat();
            }
            else _hp = value;
        }
    }

    public int Population
    {
        get { return _population; }
        set
        {
            if (value <= 0) _population = 0;
            else _population = value;
        }
    }

    public int Metals
    {
        get { return _metals; }
        set
        {
            if (value <= 0) _metals = 0;
            else _metals = value;
        }
    }

    public int Crystals
    {
        get { return _crystals; }
        set
        {
            if (value <= 0) _crystals = 0;
            else _crystals = value;
        }
    }

    public int PopGen
    {
        get { return _popGen; }
        set
        {
            if (value <= 0) _popGen = 0;
            else _popGen = value;
        }
    }

    public int MetGen
    {
        get { return _metGen; }
        set
        {
            if (value <= 0) _metGen = 0;
            else _metGen = value;
        }
    }

    public int CryGen
    {
        get { return _cryGen; }
        set
        {
            if (value <= 0) _cryGen = 0;
            else _cryGen = value;
        }
    }

    void Start()
    {
        if (PlayerHand.name.Equals("PlayerHand"))
        {
            Turn.MatchStart();
            Turn.StartTurn();
            Turn.PlayPhase();
        }
    }

    void Update()
    {
        Health.GetComponent<TMPro.TextMeshProUGUI>().text = $"{HP}";
        PopulationDisplay.GetComponent<TMPro.TextMeshProUGUI>().text = $"{Population}";
        MetalsDisplay.GetComponent<TMPro.TextMeshProUGUI>().text = $"{Metals}";
        CrystalsDisplay.GetComponent<TMPro.TextMeshProUGUI>().text = $"{Crystals}";
        GeneratorsDisplay.GetComponent<TMPro.TextMeshProUGUI>().text = $"Pop:{PopGen}, Mtl:{MetGen}, Cry:{CryGen}";
        ArmorDisplay.GetComponent<TMPro.TextMeshProUGUI>().text = $"{Armor}";
        MagicBarrierDisplay.GetComponent<TMPro.TextMeshProUGUI>().text = $"{MagicBarrier}";
    }

    void DeclareDefeat()
    {
        GameObject winner = GameObject.Find("Player");
        if (PlayerHand.name.Equals("PlayerHand")) winner = GameObject.Find("Enemy");
        GameObject victory = new GameObject();
        victory.transform.SetParent(GameObject.Find("Main Canvas").transform);
        victory.AddComponent<Image>();
        victory.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/" + winner.name + "Victory");
        victory.transform.SetLocalPositionAndRotation(new Vector3(0, 0, 0), Quaternion.identity);
        victory.GetComponent<RectTransform>().sizeDelta = new Vector2(Constants.VICTORY_GRAPHIC_WIDTH, Constants.VICTORY_GRAPHIC_WIDTH);
    }

    public void SetIfCardsCanBePlayedBasedOnTurnOrPhase(bool value)
    {
        ICard[] cards = PlayerHand.GetComponentsInChildren<ICard>();
        foreach (ICard card in cards) card.SetPlayableBecauseOtherPlayerTurnOrWrongPhase(value);
    }

    //Public method used to Add a card to the player's Hand
    public void AddCard(string cardName)
    {
        GameObject cardObject = PrefabUtility.LoadPrefabContents($"Assets/Resources/CardPrefabs/{cardName}.prefab");
        GameObject actualCard = Instantiate(cardObject, new Vector2(0, 0), Quaternion.identity);
        actualCard.transform.SetParent(PlayerHand.transform);
        if (PlayerHand.name.Equals("EnemyHand"))
        {
            actualCard.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/card-cover");
        }
        PrefabUtility.UnloadPrefabContents(cardObject);
    }

    public int[] GetResourcesAndGeneratorsAndHP()
    {
        //Will change to 8 I think once I implement Hero stuff
        int[] resourcesAndGenerators = new int[7];
        resourcesAndGenerators[0] = Population;
        resourcesAndGenerators[1] = Metals;
        resourcesAndGenerators[2] = Crystals;
        resourcesAndGenerators[3] = PopGen;
        resourcesAndGenerators[4] = MetGen;
        resourcesAndGenerators[5] = CryGen;
        resourcesAndGenerators[6] = HP;

        return resourcesAndGenerators;
    }

    public void GenerateResources()
    {
        Population += PopGen;
        Metals += MetGen;
        Crystals += CryGen;
    }

    public void SendToDeadPile(GameObject card)
    {
        card.transform.SetParent(PlayerDeadPile.transform, false);
        card.transform.SetLocalPositionAndRotation(new Vector2(0, 0), Quaternion.identity);
        card.GetComponent<Image>().enabled = false;
    }
}
