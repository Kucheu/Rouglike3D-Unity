using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static Options options = new Options();

    // Start is called before the first frame update
    void Start()
    {
        

        SaveOptions.LoadPlayerOptions();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
