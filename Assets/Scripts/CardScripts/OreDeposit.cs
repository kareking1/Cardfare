using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OreDeposit : ICard
{
    public OreDeposit() => base.Constructor("Ore Deposit", 0, "Physical", new List<int>() { 0, -2, 0, 0, 0, 0, 0, 0 });
}
