using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowBarrier : ICard
{
    public YellowBarrier() => base.Constructor("YellowBarrier", 0, "Physical", new List<int>() { 10, 0, 3, 0, 0, 0, 0, 0 }, false, 0, 0, 6);
}
