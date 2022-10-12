using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class States : MonoBehaviour //  change to scriptable object soon, im just too lazy as of rn too many errors :(
{
    public bool canSeePlayer, isHurt;
    protected BotHealth bHealth;
    public States deathState;
    public int damage = 5;
    protected StateManager stMan;
    protected Rigidbody2D rg2D;
    protected bool gotInfo = false;
    public virtual void getInfo()
    {
        stMan = FindObjectOfType<StateManager>();
        rg2D = stMan.rb;
        bHealth = FindObjectOfType<BotHealth>();
    }
    public abstract States runCurrentState();
    public virtual void attack(GameObject gm)
    {
        gm.GetComponent<Health>().affect(damage, true);
        
    }
}
