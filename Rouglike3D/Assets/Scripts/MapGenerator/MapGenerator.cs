using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    //Load from MapLoader
    Room[,] rooms;
    protected int mapLenght, mapWidth;
    GameObject door;
    GameObject wallsContainer;

    private int currentRow = 0;
    private int currentColumn = 0;

    private bool mapComplete = false;

    public MapGenerator(Room[,] rooms, GameObject door, GameObject wallsContainer)
    {
        this.rooms = rooms;
        mapLenght = rooms.GetLength(0);
        mapWidth = rooms.GetLength(1);

        this.door = door;
        this.wallsContainer = wallsContainer;
    }

    public void Generate()
    {
        rooms[currentRow, currentColumn].generatorVisited = true;

        while(!mapComplete)
        {
            PathCreate();
            FindNewPath();
        }
    }

    private void PathCreate()
    {
        while (PathIsAvaible(currentRow, currentColumn))
        {
            int direction = Random.Range(1, 5);

            if(direction == 1 && RoomIsAvaible(currentRow - 1 ,currentColumn))
            {
                Debug.Log("North " + currentRow + " " + currentColumn);
                rooms[currentRow, currentColumn].northWall = ChangeWall(rooms[currentRow, currentColumn].northWall);
                rooms[currentRow - 1, currentColumn].southWall = ChangeWall(rooms[currentRow-1, currentColumn].southWall);
                currentRow--;

                
                //North
            } else if(direction == 2 && RoomIsAvaible(currentRow, currentColumn + 1))
            {
                Debug.Log("East " + currentRow + " " + currentColumn);
                rooms[currentRow, currentColumn].eastWall = ChangeWall(rooms[currentRow, currentColumn].eastWall);
                rooms[currentRow, currentColumn + 1].westWall = ChangeWall(rooms[currentRow, currentColumn + 1].westWall);
                currentColumn++;

                
                //East
            }
            else if( direction == 3 && RoomIsAvaible(currentRow + 1, currentColumn))
            {
                Debug.Log("South " + currentRow + " " + currentColumn);
                rooms[currentRow, currentColumn].southWall = ChangeWall(rooms[currentRow, currentColumn].southWall);
                rooms[currentRow + 1, currentColumn].northWall = ChangeWall(rooms[currentRow + 1, currentColumn].northWall);
                currentRow++;


                //South
            } else if (direction == 4 && RoomIsAvaible(currentRow, currentColumn - 1))
            {
                Debug.Log("West " + currentRow + " " + currentColumn);
                rooms[currentRow, currentColumn].westWall = ChangeWall(rooms[currentRow, currentColumn].westWall);
                rooms[currentRow, currentColumn - 1].eastWall = ChangeWall(rooms[currentRow, currentColumn - 1].eastWall);
                currentColumn--;


                //West
            }
            
            rooms[currentRow, currentColumn].generatorVisited = true;
        }
    }

    private void FindNewPath()
    {
        mapComplete = true;

        for (int i = 0; i < mapLenght; i++)
        {
            for (int j = 0; j < mapWidth; j++)
            {
                if(!rooms[i,j].generatorVisited && AdjacentRoomIsVisited(i,j))
                {
                    mapComplete = false;
                    ChangeAdjacentRoomWall(i,j);
                    rooms[i, j].generatorVisited = true;
                    currentRow = i;
                    currentColumn = j;
                    return;
                }

            }
        }
    }


    private bool PathIsAvaible(int row, int column)
    {
        int avaiblePath = 0;

        if (row > 0 && !rooms[row - 1,column].generatorVisited)
        {
            avaiblePath++;
        }

        if (row < mapLenght-1 && !rooms[row + 1, column].generatorVisited)
        {
            avaiblePath++;
        }

        if (column > 0 && !rooms[row , column - 1].generatorVisited)
        {
            avaiblePath++;
        }

        if (column < mapWidth-1 && !rooms[row, column + 1].generatorVisited)
        {
            avaiblePath++;
        }
        
        return avaiblePath > 0;
    }

    private bool RoomIsAvaible(int row, int column)
    {
        if(row >= 0 && row < mapLenght && column >= 0 && column < mapWidth && !rooms[row,column].generatorVisited)
        {
            return true;
        } else
        {
            return false;
        }
        
    }

    private GameObject ChangeWall(GameObject wall)
    {
        if (wall != null)
        {
            Transform transform = wall.transform;
            GameObject.Destroy(wall);
            int ifWall = Random.Range(0, 100);
            if(ifWall < 30)
            {
                GameObject newWall = Instantiate(door, transform.position, transform.rotation);
                newWall.transform.parent = wallsContainer.transform;
                return newWall;
            }
            else
            {
                return null;
            }


        }
        else
        {
            return null;
        }
    }

    private bool AdjacentRoomIsVisited(int row, int column)
    {
        int visitedRooms = 0;

        if(row > 0 && rooms[row - 1,column].generatorVisited)
        {
            visitedRooms++;
        }

        if(column > 0 && rooms[row, column - 1].generatorVisited)
        {
            visitedRooms++;
        }

        if(row < mapLenght-1 && rooms[row + 1, column].generatorVisited)
        {
            visitedRooms++;
        }
        
        if(column < mapWidth-1 && rooms[row, column +1].generatorVisited)
        {
            visitedRooms++;
        }

        return visitedRooms > 0;
    }

    private void ChangeAdjacentRoomWall(int row, int column)
    {
        bool wallChanged = false;

        while (!wallChanged)
        {
            int direction = Random.Range (1, 5);

            if (direction == 1 && row > 0 && rooms[row - 1, column].generatorVisited)
            {
                ChangeWall(rooms[row, column].northWall);
                ChangeWall(rooms[row - 1, column].southWall);
                wallChanged = true;
            }
            else if (direction == 2 && row < (mapLenght - 2) && rooms[row + 1, column].generatorVisited)
            {
                ChangeWall(rooms[row, column].southWall);
                ChangeWall(rooms[row + 1, column].northWall);
                wallChanged = true;
            }
            else if (direction == 3 && column > 0 && rooms[row, column - 1].generatorVisited)
            {
                ChangeWall(rooms[row, column].westWall);
                ChangeWall(rooms[row, column - 1].eastWall);
                wallChanged = true;
            }
            else if (direction == 4 && column < (mapWidth - 2) && rooms[row, column + 1].generatorVisited)
            {
                ChangeWall(rooms[row, column].eastWall);
                ChangeWall(rooms[row, column + 1].westWall);
                wallChanged = true;
            }
        }
    }
}
