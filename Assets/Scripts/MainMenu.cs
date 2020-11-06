using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class MainMenu : MonoBehaviour
{

    public GameObject panel;  
    public void LoadScene (string sceneName)

    {

        StartCoroutine(Load(sceneName)); 
    
    }
    
    public void Quit()
    {
        Application.Quit(); 
    }


    IEnumerator    Load(string sceneName)

    {
        panel.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene(sceneName);
    }
    // Start is called before the first frame update
    void Start()
    { 
    }

    // Update is called once per frame
    void Update()
    {
    }
}
