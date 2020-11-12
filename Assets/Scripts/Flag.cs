using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Flag : MonoBehaviour
{

    // Finish Flag   Works Good  

    public string sceneName; 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))

        {
            SceneManager.LoadScene(sceneName);
        }
    }
    // Start is called before the first frame update
    void Start()
    {

        PlayerPrefs.SetInt(SceneManager.GetActiveScene().name,1); 

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
