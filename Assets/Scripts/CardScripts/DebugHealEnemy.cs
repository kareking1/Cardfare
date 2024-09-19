using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugHealEnemy : ICard
{
    public DebugHealEnemy() => base.Constructor("DebugHealEnemy", -81, "Physical", new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 });
}
