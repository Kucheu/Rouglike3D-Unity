using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameplayCore.Menu;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public PageController pageController;
    public PageType fistPage = PageType.none;

    //character choose menu
    public ToggleGroup charactersToggle;
    public bool canStart = false;



    // Start is called before the first frame update
    void Start()
    {
        pageController.TurnPageOn(fistPage);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pageController.StepBackPage())
            {
                Debug.Log("Nie da się cofnąć!");
            }
        
        }
    }
    
    public void ChangePage(Page _page)
    {
        pageController.TurnPageOff(_page.previousPageType, _page.pageType);
    }

    public void ExitGame()
    {

    }

    public void StepBackPage()
    {
        pageController.StepBackPage();
    }

    public void StartGame()
    {
        IEnumerable<Toggle> charactersEnumerable = charactersToggle.ActiveToggles();
        if (charactersEnumerable.Any())
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            Debug.Log("Nie masz wybranej postaci!");
        }


    }
}
