using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomPicker : MonoBehaviour
{
    public GameObject[] floorPlan;
    private void Start()
    {
        int rand = (int)Random.Range(0,floorPlan.Length);
        //Debug.Log(rand + " floorplan length :" + floorPlan.Length);
        floorPlan[rand].SetActive(true);
    }
}
