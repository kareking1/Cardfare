using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalGenerator : ICard
{
    public CrystalGenerator() => base.Constructor("Crystal Generator", 0, "Physical", new List<int>() { 0, 0, 3, 0, 0, -1, 0, 0 });
}
