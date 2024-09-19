using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalDeposit : ICard
{
    public CrystalDeposit() => base.Constructor("Crystal Deposit", 0, "Physical", new List<int>() { 0, 0, -1, 0, 0, 0, 0, 0 });
}
