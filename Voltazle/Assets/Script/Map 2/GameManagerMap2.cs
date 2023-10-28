using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Movement;

public class GameManagerMap2 : MonoBehaviour
{
    public static int fuse = 0;
    public static bool fuseBox = false;
    public static bool fuseButton = false;
    private static GameManagerMap2 instance;
    private static GameObject gate;

    [SerializeField] public List<GameObject> info = new List<GameObject>();

    public static void ObtainFuse1(){
        instance.StartCoroutine(infoFloating(instance.info[0]));
    }
    public static void ObtainFuse2(){
        instance.StartCoroutine(infoFloating(instance.info[1]));
    }
    public static void isHaveFuse(){
        if(fuse > 0){
            fuseBox = true;
            instance.StartCoroutine(infoFloating(instance.info[4]));
            Debug.Log("Fuse Terpasang");
        }else if(fuse < 1){
            Debug.Log("No Fuse");
            instance.StartCoroutine(infoFloating(instance.info[3]));
        }
    }

    public static void isFusePlaced1(){
        if(fuseBox){
            fuseButton = true;
            Debug.Log("Electricity On");
            instance.StartCoroutine(infoFloating(instance.info[5]));
            instance.info[2].SetActive(false);
            gate.GetComponent<Gate>().enabled = true;
        }else if(!fuseBox){
            Debug.Log("Need Fuse");
            instance.StartCoroutine(infoFloating(instance.info[6]));
        }
    }
    // public static void isFusePlaced2(){
    //     if(fuseBox){
    //         fuseButton = true;
    //         Debug.Log("Electricity On");
    //         instance.StartCoroutine(infoFloating(instance.info[]));
    //     }else if(!fuseBox){
    //         Debug.Log("Need Fuse");
    //         instance.StartCoroutine(infoFloating(instance.info[]));
    //     }
    // }

    public static void isElectricityOn(){
        if(fuseButton){
            Debug.Log("Naik Lift");
            // move.isUpLift = true;
            // instance.StartCoroutine(infoFloating(instance.info[6]));
            // instance.info[9].SetActive(true);
            // instance.info[10].SetActive(true);
        }else if(!fuseButton){
            Debug.Log("Need Electricity");
            instance.StartCoroutine(infoFloating(instance.info[5]));
            Tutorial.pressLift = true;
        }
    }

    // public static void isPuzzleOn(){
    //     if(fuseButton){
    //         Debug.Log("Puzzle");
    //         PuzzleObject.onInteractable();
    //     }else if(!fuseButton){
    //         Debug.Log("Need Electricity");
    //     }
    // }

    public static void isLaserOn(){
        if(fuseButton){
            Debug.Log("Laser off");
        }else if(!fuseButton){
            Debug.Log("Need Electricity");
        }
    }
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
    }
}
