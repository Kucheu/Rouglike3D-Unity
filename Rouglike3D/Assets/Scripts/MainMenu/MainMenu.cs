using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject MainMenuUI;
    public GameObject optionsMenuUI;

    // Start is called before the first frame update
    void Start()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
                if (optionsMenuUI.activeSelf)
                {
                    OptionsMenuSwitch();
                }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OptionsMenuSwitch()
    {
        if (MainMenuUI.activeSelf)
        {

            MainMenuUI.SetActive(false);
            optionsMenuUI.SetActive(true);
            optionsMenuUI.GetComponent<OptionsMenu>().OptionsUpdate();

        }
        else
        {

            MainMenuUI.SetActive(true);
            optionsMenuUI.SetActive(false);

            SaveOptions.LoadPlayerOptions();
        }
    }

    public void SaveOptionsMenu()
    {
        SaveOptions.SavePlayerOptions();
    }
}
