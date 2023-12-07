using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RoomData", menuName = "ScriptableObjects/RoomData", order = 1)]
public class RoomData : ScriptableObject
{
    public GameObject[] rooms_oneDoor;
    public GameObject[] rooms_twoDoor;
    public GameObject[] rooms_threeDoor;
    public GameObject[] rooms_fourDoor;

}