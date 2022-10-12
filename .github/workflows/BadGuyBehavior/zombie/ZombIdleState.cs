using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ZombIdleState : States
{
    public States seekState;
    public float counterMax = 5f;
    private Vector2 v2;
    float counter = 0f;
    public override States runCurrentState()
    {
        rg2D.velocity = changeVelocity();
        Debug.Log(bHealth.health); //  it cant find this for some reason L bozo
        Wander();
        States rState = canSeePlayer ? seekState : this;
        return rState;
    }
    private void Wander()
    {
        counter += Time.deltaTime;
        if(counter>= 2f)
        {
            rg2D.velocity = changeVelocity();
            counter = 0;
        }
    }
    private Vector2 changeVelocity()
    {
        v2.x = Random.Range(-1f, 1f);
        v2.y = Random.Range(-1f, 1f);
        v2.Normalize();
        return v2 * .2f;
    }
}
