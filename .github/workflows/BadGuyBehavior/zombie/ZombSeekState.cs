using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ZombSeekState : States
{
    [SerializeField]private Transform parentTrans, playerTrans2;
    public float speed;
    private Vector2 ZVelocity;
    public override void getInfo()
    {
        base.getInfo();
        parentTrans = stMan.trans;
        playerTrans2 = stMan.playerTrans;
    }
    
    public override States runCurrentState()
    {
        Chase();
        if (bHealth.health <= 0)
        {
            return deathState;
        }
        return this;
    }
    private void Chase()
    {
        ZVelocity.x = playerTrans2.position.x - parentTrans.position.x;
        ZVelocity.y = playerTrans2.position.y - parentTrans.position.y;
        ZVelocity.Normalize();
        rg2D.velocity = ZVelocity * speed;
    }
}
