using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FalseCard : ICard
{
    public FalseCard() => base.Constructor("FalseCard", 0, "Physical", new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0 });
}
