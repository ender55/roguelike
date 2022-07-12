using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
     [SerializeField] private int currentLevel;
     [SerializeField] private Vector2Int roomSize = new Vector2Int(22, 10);
     [SerializeField] private int roomsAmount;
     [SerializeField] private RoomComposition[] roomComposition;

     private List<Vector2> roomsMap;

     private void GenerateDungeonMap()
     {
          roomsMap = new List<Vector2>(roomsAmount);
          roomsMap.Add(new Vector2(0, 0));
          
          Vector2 vectorUp = Vector2.up;
          roomsMap.Add(vectorUp);
          
          Vector2 vectorDown = Vector2.down;
          roomsMap.Add(vectorDown);
          
          Vector2 vectorLeft = Vector2.left;
          roomsMap.Add(vectorLeft);
          
          Vector2 vectorRight = Vector2.right;
          roomsMap.Add(vectorRight);
          
          int amount = (roomsAmount - 5) / 4;
          
          for (int i = 0; i < amount; i++)
          {
               vectorUp += RandomDirection();
               if (!roomsMap.Contains(vectorUp))
               {
                    roomsMap.Add(vectorUp);
               }
          }
          
          for (int i = 0; i < amount; i++)
          {
               vectorDown += RandomDirection();
               if (!roomsMap.Contains(vectorDown))
               {
                    roomsMap.Add(vectorDown);
               }
          }
          
          for (int i = 0; i < amount; i++)
          {
               vectorLeft += RandomDirection();
               if (!roomsMap.Contains(vectorLeft))
               {
                    roomsMap.Add(vectorLeft);
               }
          }
        
          for (int i = 0; i < amount; i++)
          {
               vectorRight += RandomDirection();
               if (!roomsMap.Contains(vectorRight))
               {
                    roomsMap.Add(vectorRight);
               }
               
          }

          while (roomsMap.Count < roomsAmount)
          {
               var index = Random.Range(1, roomsMap.Count);
               Vector2 direction = roomsMap[index] + RandomDirection();
               if (!roomsMap.Contains(direction))
               {
                    roomsMap.Add(direction);
               }
          }
     }

     private Vector2 RandomDirection()
     {
          var random = Random.Range(0, 4);
          switch (random)
          {
              case 0:
                   return new Vector2(0, 1);
              case 1:
                   return new Vector2(0, -1);
              case 2:
                   return new Vector2(1, 0);
              case 3:
                   return new Vector2(-1, 0);
              default:
                   return Vector2.zero;
          }
     }
     
     private void CreateRoom(Vector2 coordinates)
     {
          GameObject obj = new GameObject("Room");
          Room room = obj.AddComponent<Room>();
          
          room.RoomSize = roomSize;

          room.Coordinates = coordinates * roomSize;


          bool isUp = false;
          bool isDown = false;
          bool isLeft = false;
          bool isRight = false;
          
          if (roomsMap.Contains(coordinates + Vector2.up))
          {
               isUp = true;
          }
          
          if (roomsMap.Contains(coordinates + Vector2.down))
          {
               isDown = true;
          }
          
          if (roomsMap.Contains(coordinates + Vector2.left))
          {
               isLeft = true;
          }
          
          if (roomsMap.Contains(coordinates + Vector2.right))
          {
               isRight = true;
          }

          if (isUp)
          {
               if (isDown)
               {
                    if (isLeft)
                    {
                         if (isRight)
                         {
                              room.Walls = roomComposition[currentLevel].walls.UDLRwall;
                         }
                         else
                         {
                              room.Walls = roomComposition[currentLevel].walls.UDLwall;
                         }
                    }
                    else
                    {
                         if (isRight)
                         {
                              room.Walls = roomComposition[currentLevel].walls.UDRwall;
                         }
                         else
                         {
                              room.Walls = roomComposition[currentLevel].walls.UDwall;
                         }
                    }
               }
               else
               {
                    if (isLeft)
                    {
                         if (isRight)
                         {
                              room.Walls = roomComposition[currentLevel].walls.ULRwall;
                         }
                         else
                         {
                              room.Walls = roomComposition[currentLevel].walls.ULwall;
                         }
                    }
                    else
                    {
                         if (isRight)
                         {
                              room.Walls = roomComposition[currentLevel].walls.URwall;
                         }
                         else
                         {
                              room.Walls = roomComposition[currentLevel].walls.Uwall;
                         }
                    }
               }
          }
          else
          {
               if (isDown)
               {
                    if (isLeft)
                    {
                         if (isRight)
                         {
                              room.Walls = roomComposition[currentLevel].walls.DLRwall;
                         }
                         else
                         {
                              room.Walls = roomComposition[currentLevel].walls.DLwall;
                         }
                    }
                    else
                    {
                         if (isRight)
                         {
                              room.Walls = roomComposition[currentLevel].walls.DRwall;
                         }
                         else
                         {
                              room.Walls = roomComposition[currentLevel].walls.Dwall;
                         }
                    }
               }
               else
               {
                    if (isLeft)
                    {
                         if (isRight)
                         {
                              room.Walls = roomComposition[currentLevel].walls.LRwall;
                         }
                         else
                         {
                              room.Walls = roomComposition[currentLevel].walls.Lwall;
                         }
                    }
                    else
                    {
                         if (isRight)
                         {
                              room.Walls = roomComposition[currentLevel].walls.Rwall;
                         }
                    }
               }
          }

          if (roomComposition[currentLevel].environment.Length != 0)
          {
               var envIndex = Random.Range(0, roomComposition[currentLevel].environment.Length);
               if (coordinates != Vector2.zero)
               {
                    room.Environment = roomComposition[currentLevel].environment[envIndex];
               }
          }

          if (roomComposition[currentLevel].floor.Length != 0)
          {
                var floorIndex = Random.Range(0, roomComposition[currentLevel].floor.Length);
                room.Floor = roomComposition[currentLevel].floor[floorIndex];
          }

          if (roomComposition[currentLevel].enemies.Length != 0)
          {
               room.Enemies = roomComposition[currentLevel].enemies;
          }

          if (roomComposition[currentLevel].doors)
          {
               room.Doors = roomComposition[currentLevel].doors;
          }
          
          room.GenerateRoom();
     }

     private void GenerateDungeon()
     {
          GenerateDungeonMap();
          foreach (var coordinate in roomsMap)
          {
               CreateRoom(coordinate);
          }
     }

     private void Awake()
     {
          GenerateDungeon();
          AstarPath.active.Scan();
     }
}
