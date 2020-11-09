using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool Paused = false;




    public GameObject PauseMenuUI; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
         if(Input.GetKeyDown(KeyCode.Escape))

        {
             if(Paused)

            {
                Resume();
            }

             else

            {
                GamePaused();
            }
        }


    }

       public void Resume()

    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        Paused = false; 
    }

    void GamePaused()

    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        Paused = false;
    }


    public void Load()

    {


        Time.timeScale = 1f;


        SceneManager.LoadScene("MainMenu");         
    }

    public void Quit()

    {
        Application.Quit(); 
    }

}

