using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopGeneratorDebug : ICard
{
   public PopGeneratorDebug() => base.Constructor("PopGeneratorDebug", 0, "Physical", new List<int>() { 5, 0, 0, -1, 0, 0, 0, 0 });
}
