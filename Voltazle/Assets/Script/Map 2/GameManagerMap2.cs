using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Movement;
using UnityEngine.SceneManagement;

public class GameManagerMap2 : MonoBehaviour
{
    public static int fuse = 0;
    public static bool fuseBox = false;
    public static bool fuseButton = false;

    public static bool fuseBox2 = false;
    public static bool fuseButton2 = false;
    private static GameManagerMap2 instance;
    private static GameObject gate;
    private static GameObject boxRail;
    public GameObject objectToToggle;
    private bool isObjectActive = false;

    [SerializeField] public List<GameObject> info = new List<GameObject>();
    [SerializeField] public List<GameObject> laser = new List<GameObject>();

    public static void ObtainFuse1(){
        instance.StartCoroutine(infoFloating(instance.info[0]));
    }
    public static void ObtainFuse2(){
        instance.StartCoroutine(infoFloating(instance.info[1]));
    }
    public static void isHaveFuse1(){
        if(fuse > 0){
            fuseBox = true;
            instance.StartCoroutine(infoFloating(instance.info[4]));
            Debug.Log("Fuse 1 Terpasang");
        }else if(fuse < 1){
            Debug.Log("No Fuse 1");
            instance.StartCoroutine(infoFloating(instance.info[3]));
        }
    }
    public static void isHaveFuse2(){
        if(fuse > 1){
            fuseBox2 = true;
            instance.StartCoroutine(infoFloating(instance.info[8]));
            Debug.Log("Fuse 2 Terpasang");
        }else if(fuse < 2){
            Debug.Log("No Fuse 2");
            instance.StartCoroutine(infoFloating(instance.info[7]));
        }
    }

    public static void isFusePlaced1(){
        if(fuseBox){
            fuseButton = true;
            Debug.Log("Electricity On");
            instance.StartCoroutine(infoFloating(instance.info[5]));
            instance.info[2].SetActive(false);
            gate.GetComponent<Gate>().enabled = true;
            instance.laser[0].GetComponent<LaserTrap>().LaserOn();
            instance.laser[1].GetComponent<LaserTrap>().LaserOn();
        }else if(!fuseBox){
            Debug.Log("Need Fuse 1");
            instance.StartCoroutine(infoFloating(instance.info[6]));
        }
    }
    public static void isFusePlaced2(){
        if(fuseBox2){
            fuseButton2 = true;
            Debug.Log("Box Dropped");
            instance.StartCoroutine(infoFloating(instance.info[9]));
            Destroy(boxRail);      
        }else if(!fuseBox2){
            Debug.Log("Need Fuse 2");
            instance.StartCoroutine(infoFloating(instance.info[10]));
        }
    }

    public static void isLaserOn(){
        if(fuseButton){
            Debug.Log("Laser off");
            instance.StartCoroutine(infoFloating(instance.info[11]));
            Destroy(instance.laser[0]);
            Destroy(instance.laser[1]);
        }else if(!fuseButton){
            Debug.Log("Need Electricity");
        }
    }

    // public static void EscapeOpened(){
    //     sprite.color = Color.black;
    // }
    public static IEnumerator infoFloating(GameObject info){
        info.SetActive(true);
        yield return new WaitForSeconds(2f);
        info.SetActive(false);
    }

    void Start(){
        if(!instance)
                {
                    instance = FindObjectOfType<GameManagerMap2>();
                    if(!instance)
                    {
                        instance = new GameObject ("GameManagerMap2").AddComponent<GameManagerMap2>();
                    }
                }
        gate = GameObject.FindGameObjectWithTag("Gate");
        boxRail = GameObject.FindGameObjectWithTag("Railing");
    }

    public void Update(){
        if (Input.GetKeyDown(KeyCode.Escape) && !isObjectActive)
        {   objectToToggle.SetActive(true);
            isObjectActive = true;
            move.inControl = false;
            
        }else if(Input.GetKeyDown(KeyCode.Escape) && isObjectActive){
            objectToToggle.SetActive(false);
            isObjectActive = false;
            move.inControl = true;
        }
    }
    public void LoadMainMenu(){
        SceneManager.LoadSceneAsync(0);
    }

}
