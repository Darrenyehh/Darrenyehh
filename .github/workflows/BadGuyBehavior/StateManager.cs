using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    [SerializeField] public States currentState;
    public int damage;
    public Rigidbody2D rb;
    public Transform playerTrans, trans;
    //for zombie all chase method
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentState.damage = this.damage;
    }
    private void LateUpdate()
    {
        runStateMachine();
    }
    private void runStateMachine()
    {
        States nextState = currentState;
        if(nextState != null)
        {
            switchState(nextState);
        }
        currentState.runCurrentState();
    }
    private void switchState(States nextState)
    {
        nextState.canSeePlayer = currentState.canSeePlayer;
        currentState.damage = this.damage;
        currentState = nextState;
        currentState.getInfo();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerTrans = collision.gameObject.transform;
            currentState.canSeePlayer = true;
            GameEvents.gameEvents.ZombieAllChase();
        }
    }
    private void OnCollisionStay2D(Collision2D gm)
    {
        if (gm.gameObject.CompareTag("Player"))
        {
            currentState.attack(gm.gameObject);
        }
    }
    public void whenHurtAction()
    {//what mob does when it gets hurt
        currentState.canSeePlayer = true;
    }
}
