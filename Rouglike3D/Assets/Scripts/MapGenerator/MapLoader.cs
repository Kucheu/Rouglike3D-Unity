using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapLoader : MonoBehaviour
{
    public int mapLenght, mapWidth;
    public GameObject floor, wall, door;

    public float size = 10f;
    public float wallSize = 5f;

    public GameObject floorsContainer, wallsContainer;
    private Room[,] rooms;

    // Start is called before the first frame update
    void Start()
    {
        CreateMap();

        MapGenerator mapGenerator = new MapGenerator(rooms, door, wallsContainer);
        mapGenerator.Generate();
    }

    private void CreateMap()
    {
        rooms = new Room[mapLenght, mapWidth];

        for(int i = 0; i < mapLenght; i++)
        {
            for(int j = 0; j < mapWidth; j++)
            {
                //Floor
                rooms[i, j] = new Room();
                rooms[i, j].floor = Instantiate(floor, new Vector3(i*size,0,j*size),Quaternion.identity) as GameObject;
                rooms[i, j].floor.transform.parent = floorsContainer.transform;

                //North
                rooms[i,j].northWall = Instantiate(wall, new Vector3((i * size) - (size/2), wallSize/2, j * size), Quaternion.identity) as GameObject;
                rooms[i, j].northWall.transform.Rotate(Vector3.up * 90f);
                rooms[i, j].northWall.transform.parent = wallsContainer.transform;

                //East
                rooms[i, j].eastWall = Instantiate(wall, new Vector3(i * size, wallSize / 2, (j * size) + (size/2)), Quaternion.identity) as GameObject;
                rooms[i, j].eastWall.transform.parent = wallsContainer.transform;

                //South
                rooms[i, j].southWall = Instantiate(wall, new Vector3((i * size) + (size / 2), wallSize / 2, j * size), Quaternion.identity) as GameObject;
                rooms[i, j].southWall.transform.Rotate(Vector3.up * 90f);
                rooms[i, j].southWall.transform.parent = wallsContainer.transform;


                //West
                rooms[i, j].westWall = Instantiate(wall, new Vector3(i * size, wallSize / 2, (j * size) - (size / 2)), Quaternion.identity) as GameObject;
                rooms[i, j].westWall.transform.parent = wallsContainer.transform;
            }
        }
    }
}
