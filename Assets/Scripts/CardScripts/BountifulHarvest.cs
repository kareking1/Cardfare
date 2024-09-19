using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BountifulHarvest : ICard
{
    public BountifulHarvest() => base.Constructor("Bountiful Harvest", 0, "Physical", new List<int>() { -4, 0, 0, 0, 0, 0, 0, 0 });
}
