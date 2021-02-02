using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Options : MonoBehaviour
{

    [SerializeField] public float mouseSensitivity = 3.5f;


    [Space(10)]
    //Audio
    [SerializeField] [Range(0.0f, 1.0f)] public float audioVolume = 1f;
    [SerializeField] [Range(0.0f, 1.0f)] public float brightness = 1f;

    private void Start()
    {
        AudioListener.volume = audioVolume;
        
    }


    


}
