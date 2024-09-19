using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleUtilities
{
    /*
     * THINGS TO IMPLEMENT FOR FIRST PLAYABLE ALPHA
     *  
     * Dead Pile -> Done!
     * Change in UI: Cards will be played through sub-menu and not dragging -> Done!
     * Make Layout for the game -> Done!
     * Cards for building village -> Done!
     * Castle system and building victory -> Done!
     * Sacrifice system -> Done!
     * Place cards along set position -> Done!
     * Permanents System -> Done!
     * Make zone cards go to dead pile -> Done!
     * Damage Types -> Done!
     * Magical Barrier -> Done!
     * Constants.cs -> Done!
     * Cards increasing Magical Barrier -> Done!
     * Battle steps -> Sorta
     * Guarding cards -> Done!
     * Cards with special effects from excel list
     * More cards for crystals and late game cards
     * Title Screen
     * Deck building
     * Legend/Legendary cards
     * Develop AI...
     * Save system
     * ----------PLAYABLE VERSION 0.9 REACHED----------
     * 
     * Add multiple AI with different decks
     * Add all necessary cards
     * Handle all non-programming related assets (sound, music, visuals, etc.)
     * ----------VERSION 1.0 YIPEEE!----------
     * 
     * ----------OPTIONAL----------
     * Premature End System
     * */

    public static void HandlePhysicalBattleDamage(int damage, Character defender, List<ICard> blockers)
    {
        foreach (ICard blocker in blockers)
        {
            if (blocker.BlockValue > damage)
            {
                blocker.BlockValue -= damage;
                damage = 0;
                return;
            }
            damage -= blocker.BlockValue;
            defender.SendToDeadPile(blocker.gameObject);
        }
        if (damage < defender.Armor)
        {
            defender.Armor -= damage;
            return;
        }
        defender.HP -= (damage - defender.Armor);
        defender.Armor = 0;
    }

    public static void HandleMagicalBattleDamage(int damage, Character defender, List<ICard> blockers)
    {
        foreach (ICard blocker in blockers)
        {
            if (blocker.BlockValue > damage)
            {
                blocker.BlockValue -= damage;
                damage = 0;
                return;
            }
            damage -= blocker.BlockValue;
            defender.SendToDeadPile(blocker.gameObject);
        }
        if (damage < defender.MagicBarrier)
        {
            defender.MagicBarrier -= damage;
            return;
        }
        defender.HP -= (damage - defender.MagicBarrier);
        defender.MagicBarrier = 0;
    }
}
