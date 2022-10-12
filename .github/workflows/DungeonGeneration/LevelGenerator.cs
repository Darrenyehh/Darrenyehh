using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{// Darren's dungeon generator!!! wooooooooo
    Vector2Int worldSize = new Vector2Int(4, 4);
    Room[,] rooms;
    Dictionary<int, Vector2Int> hashMap = new Dictionary<int, Vector2Int>();
    int gridSizeX, gridSizeY, numbOfRooms;
    public GameObject roomObj;

    private void Start()
    {
        numbOfRooms = ((int)Random.Range(13, 20)); // sets a random number of rooms
        gridSizeY = Mathf.RoundToInt(worldSize.y);
        gridSizeX = Mathf.RoundToInt(worldSize.x);
        DrunkWalker();
        checkForNeighbors();
        //print();
        createRooms();
    }
    void DrunkWalker()
    {//method that creates the rooms by making it randomly walk in cardinal directions
        rooms = new Room[gridSizeX * 2, gridSizeY * 2];//makes the size of the array
        Vector2Int currentStep = new Vector2Int (gridSizeX,gridSizeY);//making a point where the walker starts 
        rooms[gridSizeX, gridSizeY] = new Room(Vector2Int.zero , 0);//creates a room in the middle of the array
        int hashCount = 1;
        hashMap.Add(0, currentStep);
        for (int i = 0; i < numbOfRooms; i++)
        {
            int RandomNumber = Random.Range(1, 5);//makes random numb from 1 - 4 then assigns which direction the thingy goes based on the room
            currentStep = RandomNumber == 1 ? currentStep+= new Vector2Int(1,0) :
                RandomNumber == 2 ? currentStep += new Vector2Int(-1, 0) :
                RandomNumber == 3 ? currentStep += new Vector2Int(0, 1) :
                currentStep += new Vector2Int(0, -1);
                int checkR = checkRoom(currentStep);
                if (checkR == 0)
                {//checks if there is already an existing room in that location
                    rooms[(int)currentStep.x, (int)currentStep.y] = new Room(currentStep , 0);
                    hashMap.Add(hashCount, currentStep);
                    hashCount++;
                }
                else if (checkR == 1)
                {//if there is already a room there
                    i--;
                }
                else
                {//out of bounds lol
                    currentStep = new Vector2Int(gridSizeX, gridSizeY);
                }
        }
    }
    int checkRoom(Vector2Int v2)
    {//checks if there is a room in that pos and if it goes out of array bounds, 0 means free 1 means taken and 2 means out of bounds
        return v2.x == 8f || v2.x == 0f ? 2 :
            v2.y == 8f || v2.y == 0f ? 2 :
            rooms[v2.x, v2.y] == null ? 0 : 1;  
    }
    void checkForNeighbors()
    {//checks for neighbors at each room object and then sets the doorX bool to true/false
        foreach (var item in hashMap)
        {
            Vector2Int tempV2 = item.Value;
            rooms[tempV2.x,tempV2.y].doorRight = tempV2.y == 7 ? false :
                rooms[tempV2.x, tempV2.y + 1] != null ? true : false;
            rooms[tempV2.x,tempV2.y].doorLeft = tempV2.y == 0 ? false :
                rooms[tempV2.x, tempV2.y - 1] != null ? true : false;
            rooms[tempV2.x,tempV2.y].doorTop = tempV2.x == 0 ? false :
                  rooms[tempV2.x - 1, tempV2.y] != null ? true : false;
            rooms[tempV2.x,tempV2.y].doorBot = tempV2.x == 7 ? false :
                  rooms[tempV2.x + 1, tempV2.y] != null ? true : false;
        }
    }
    void print()
    {//prints numbers for rooms and the amt of doors a room has 
        string st = "";
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (rooms[i,j] == null)
                {
                    st += 0;
                }
                else
                {
                    int numbOfDoors = 0;
                    if (rooms[i, j].doorBot)
                        numbOfDoors++;
                    if (rooms[i, j].doorLeft)
                        numbOfDoors++;
                    if (rooms[i, j].doorRight)
                        numbOfDoors++;
                    if (rooms[i, j].doorTop)
                        numbOfDoors++;
                    st += numbOfDoors;

                }
            }
            st += "\n";
        }
        Debug.Log(st);
    }
    void createRooms()
    {//creates the rooms based off of the prefab
        foreach (var item in hashMap)
        {
            var cloneRoom = (GameObject)Instantiate(roomObj);
            var _door = cloneRoom.GetComponent<Door>();
            cloneRoom.transform.position = new Vector3((item.Value.x - 4) * 26, (item.Value.y - 4) * 10, 0f);

            rooms[item.Value.x, item.Value.y].SetDoors(_door);
            _door.turnDoors();
        }
    }
}
