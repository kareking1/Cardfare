using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Militia : ICard
{
    public Militia() => base.Constructor("Militia", 7, "Physical", new List<int>() { 4, 0, 0, 1, 0, 0, 0, 0 });
}
