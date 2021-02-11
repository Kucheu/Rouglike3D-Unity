using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GameplayCore.Menu;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPause = false;

    public PageController pageController;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPause)
            {
                if (!pageController.StepBackPage())
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

    private void Resume()
    {
        GameIsPause = false;
        Time.timeScale = 1f;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        pageController.TurnPageOff(PageType.PauseMenu);
    }

    private void Pause()
    {
        GameIsPause = true;
        Time.timeScale = 0f;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        pageController.TurnPageOn(PageType.PauseMenu);
    }

    public void ChangePage(Page _page)
    {
        pageController.TurnPageOff(_page.previousPageType, _page.pageType);
    }

    public void StepBackPage()
    {
        if (!pageController.StepBackPage())
        {
            Resume();
        }
    }

    public void QuitGame()
    {
        SceneManager.LoadScene(0);
        SceneManager.UnloadSceneAsync(1);
    }

   
}
