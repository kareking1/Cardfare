using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scout : ICard
{
    public Scout() => Constructor("Scout", 0, "Physical", new List<int>() { 1, 1, 0, 0, 0, 0, 0, 0 }, true, 0, 0, 0, 2, false, false);
}
