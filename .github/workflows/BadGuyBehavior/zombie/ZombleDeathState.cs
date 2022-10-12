using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombleDeathState : States
{
    public override States runCurrentState()
    {//update later hehe
        rg2D.velocity = Vector2.zero;
        return this;
    }
}
