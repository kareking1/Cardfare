using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Infantry : ICard
{
    public Infantry() => base.Constructor("Infantry", 5, "Physical", new List<int>() { 4, 1, 0, 0, 0, 0, 0, 0 });
}
