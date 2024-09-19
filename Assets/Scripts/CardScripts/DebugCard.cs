using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugCard : ICard
{
    public DebugCard() => base.Constructor("DebugCard", 0, "Physical", new List<int>() { -3, -3, -3, -3, -3, -3, 0, 0 });
}
