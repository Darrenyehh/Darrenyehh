using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room
{
    public Vector2Int gridPos;
    public bool doorTop, doorBot, doorLeft, doorRight;
    public int numbOfNeighbors, roomType;// room type is for stuff such as boss room, shop, priest or som idk u figure it out d dawg
    public Room (Vector2Int gridPos , int type)
    {
        this.gridPos = gridPos;
        this.roomType = type;
    }
    public void SetDoors(Door d)
    {
        d.doorTop = !doorTop;
        d.doorLeft = !doorLeft;
        d.doorRight = !doorRight;
        d.doorBot = !doorBot;
    }
}
