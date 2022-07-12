using System;
using UnityEngine;

[Serializable]
public struct RoomComposition
{
    public Wall walls;
    public GameObject doors;
    public Environment startRoomEnvironment;
    public Environment[] environment;
    public GameObject[] floor;
    public GameObject[] enemies;
}