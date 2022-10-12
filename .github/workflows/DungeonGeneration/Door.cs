using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [HideInInspector]public bool doorTop, doorBot, doorLeft, doorRight;
    public GameObject doorTop_, doorBot_, doorRight_, doorLeft_;
    bool isOpened = false;
    private void Start()
    {
        GameEvents.gameEvents.onClearRoom += roomHelper;
    }

    public void turnDoors()
    {
        doorTop_.SetActive(doorTop);
        doorBot_.SetActive(doorBot);
        doorLeft_.SetActive(doorLeft);
        doorRight_.SetActive(doorRight);
        clearRoom(true);
    }
    public void clearRoom(bool isClear)
    {//so theres only one thingy of this and its affecting all the doors rip
        if (!doorLeft)
            doorLeft_.SetActive(isClear);
        if (!doorRight)
            doorRight_.SetActive(isClear);
        if (!doorTop)
            doorTop_.SetActive(isClear);
        if (!doorBot)
            doorBot_.SetActive(isClear);
    }
    protected void roomHelper()
    {
        isOpened = isOpened ? false : true;
        clearRoom(isOpened);
    }
    
}
