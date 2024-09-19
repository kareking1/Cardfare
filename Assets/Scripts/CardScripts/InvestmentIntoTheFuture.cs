using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvestmentIntoTheFuture : ICard
{
    public InvestmentIntoTheFuture() => base.Constructor("Investment into the Future", 0, "Physical", new List<int>() { 0, 10, 5, -5, -4, -2, 0, 0 });
}
