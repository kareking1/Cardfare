using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle
{
    public static void InflictBattleDamage(GameObject Attacker, GameObject Defender, ICard card)
    {
        Character attackerScript = Attacker.GetComponent<Character>();
        Character defenderScript = Defender.GetComponent<Character>();
        List<ICard> blockers = new List<ICard>();
        
        if (card.DamageType.Equals("Physical"))
        {
            foreach (ICard blocker in defenderScript.PlayerPermanents.GetComponentsInChildren<ICard>())
            {
                if (blocker.BlockValue != 0 && blocker.DamageType.Equals("Physical")) blockers.Add(blocker);
            }
            BattleUtilities.HandlePhysicalBattleDamage(card.Attack, defenderScript, blockers);
        }else if (card.DamageType.Equals("Magical"))
        {
            foreach (ICard blocker in defenderScript.PlayerPermanents.GetComponentsInChildren<ICard>())
            {
                if (blocker.BlockValue != 0 && blocker.DamageType.Equals("Magical")) blockers.Add(blocker);
            }
            BattleUtilities.HandleMagicalBattleDamage(card.Attack, defenderScript, blockers);
        }
        else Defender.GetComponent<Character>().HP -= card.Attack;
    }
}
