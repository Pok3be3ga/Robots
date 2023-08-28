using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpirienceLoot : Loot
{
    [SerializeField] int expirienceValue;

    public override void Take(Collector _collector)
    {
        base.Take(_collector);
        _collector.TakeExpirience(expirienceValue);
    }
}
