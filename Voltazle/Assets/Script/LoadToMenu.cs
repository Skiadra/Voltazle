using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadToMenu : MonoBehaviour
{
    public void LoadToMenuS(){
        SceneManager.LoadSceneAsync(0);
    }
}
