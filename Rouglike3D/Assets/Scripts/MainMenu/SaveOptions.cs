using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveOptions : MonoBehaviour
{
    public static void SavePlayerOptions()
    {
        string path = Application.persistentDataPath + "/options.fun";
        string playerOptions = JsonUtility.ToJson(GameManager.options);
        System.IO.File.WriteAllText(path, playerOptions);
        
        Debug.Log("Save File");
    }
    
    public static void LoadPlayerOptions()
    {
        string path = Application.persistentDataPath + "/options.fun";
        StreamReader reader = new StreamReader(path);
        string playerOptions = reader.ReadToEnd();
        JsonUtility.FromJsonOverwrite(playerOptions, GameManager.options);


    }
    /* 
    public static PlayerController LoadPlayerOptions()
    {
        return new PlayerController();
    }
    /*
    public static void SaveBestPoints(float points)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/gameStatus.fun";
        FileStream stream = new FileStream(path, FileMode.Create);

        Points data = new Points(points);

        formatter.Serialize(stream, data);
        stream.Close();
        Debug.Log("Save");
    }

    public static Points LoadBestPoints()
    {
        string path = Application.persistentDataPath + "/gameStatus.fun";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            Debug.Log(stream);
            Points data = formatter.Deserialize(stream) as Points;
            stream.Close();


            return data;
        }
        else
        {
            return null;
        }

    }
    */
}
