using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        OptionsUpdate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OptionsUpdate()
    {
        Debug.Log(GameManager.options.audioVolume);
        slider.value = GameManager.options.audioVolume;
    }

    public void volumeChange()
    {
        GameManager.options.audioVolume = slider.value;
    }

    public void SaveOptions()
    {

    }
}
