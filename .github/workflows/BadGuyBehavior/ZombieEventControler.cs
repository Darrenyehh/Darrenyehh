using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieEventControler : MonoBehaviour
{//this class is for mobs that have mob chasing things like when a zomb chases u all of em do
    public List<StateManager> stMan;
    void Start()
    {
        GameEvents.gameEvents.onZombieAllChase += ZombChase; //gets the static object of the gameEvents class and adds the method into its action
        Find();
    }
    private List<StateManager> Find()
    {//find all statemanagers
        GameObject[] temparray = GameObject.FindGameObjectsWithTag("Mob");

        foreach (var item in temparray)
        {

            if(item.GetComponent<StateManager>())
            { 
                stMan.Add(item.GetComponent<StateManager>());
            }
        }
        return stMan;
    }
    private void ZombChase()
    {
        for (int i = 0; i < stMan.Count; i++)
        {
            stMan[i].whenHurtAction();
        }
    }
}
