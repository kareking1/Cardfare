using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carpenters : ICard
{
    public Carpenters() => Constructor("Carpenters", 0, "Physical", new List<int>() { 4, 8, 0, 0, 0, 0, 0, 0 }, false, 16);
}
