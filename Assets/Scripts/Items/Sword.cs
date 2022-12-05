using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Melee
{
    public override void InitItem()
    {
        base.itemname = "Sword";
        base.itemrarity = Rarity.COMMON;
    }
}