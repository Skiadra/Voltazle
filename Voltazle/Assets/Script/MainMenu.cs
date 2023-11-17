using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    
    // Update is called once per frame

    void Start(){
        GameManagerMap1.fuse = 0;
        GameManagerMap1.fuseBox = false;
        GameManagerMap1.fuseButton = false;
        GameManagerMap1.clickedLiftButton = false;
        Tutorial.pressLift = false;
    }
    void Update()
    {
    
    }

    public void play(){
        SceneManager.LoadSceneAsync(1);
    }

    public void exit(){
        Application.Quit();
    }
}
