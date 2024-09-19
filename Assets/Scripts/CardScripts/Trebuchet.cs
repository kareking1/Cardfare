using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trebuchet : ICard
{
    public Trebuchet() => base.Constructor("Trebuchet", 6, "Direct", new List<int>() { 3, 7, 0, 0, 0, 0, 0, 0 });
}
