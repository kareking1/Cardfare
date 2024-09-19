using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constants
{
    public const int CARD_WIDTH = 78;
    public const int CARD_HEIGHT = 99;
    public const int CARD_GRAPHIC_WIDTH = 81;
    public const int CARD_GRAPHIC_HEIGHT = 102;
    public const int VICTORY_GRAPHIC_WIDTH = 1150;
    public const int VICTORY_GRAPHIC_HEIGHT = 221;
    public static Dictionary<string, int> DEFAULT_PLAYER_VALUES = new Dictionary<string, int>
    {
        { "HP", 20 },
        { "Population", 20 },
        { "Metals", 10 },
        { "Crystals", 3 },
        { "PopulationGen", 2 },
        { "MetalsGen", 1 },
        { "CrystalsGen", 0 },
        { "Armor", 6 },
        { "Magic Barrier", 0 },
    };
    public static Vector2 SUB_MENU_TRANSLATE_VECTOR = new Vector2(0, 75);
}
