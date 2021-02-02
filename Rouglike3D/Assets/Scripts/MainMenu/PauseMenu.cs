using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPause = false;

    public GameObject pauseMenuUI;
    public GameObject optionsMenuUI;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPause)
            {
                if(optionsMenuUI.activeSelf)
                {
                    OptionsMenuSwitch();
                }
                else
                {
                    Resume();
                }
                
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPause = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPause = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void QuitGame()
    {
        SceneManager.LoadScene(0);
        SceneManager.UnloadSceneAsync(1);
    }

    public void OptionsMenuSwitch()
    {
        if(pauseMenuUI.activeSelf)
        {

            pauseMenuUI.SetActive(false);
            optionsMenuUI.SetActive(true);
            optionsMenuUI.GetComponent<OptionsMenu>().OptionsUpdate();

        }
        else
        {

            pauseMenuUI.SetActive(true);
            optionsMenuUI.SetActive(false);

            SaveOptions.LoadPlayerOptions();
        }
    }

    public void SaveOptionsMenu()
    {
        SaveOptions.SavePlayerOptions();
    }
}
