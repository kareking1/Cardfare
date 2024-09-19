using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thunderstrike : ICard
{
    public Thunderstrike() => base.Constructor("Thunderstrike", 4, "Magical", new List<int>() { 0, 0, 1, 0, 0, 0, 0, 0 });
}
