using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using static Movement;

public class GameManagerMap1 : MonoBehaviour
{
    public static int fuse = 0;
    public static bool fuseBox = false;
    public static bool fuseButton = false;
    private static GameManagerMap1 instance;

    [SerializeField] public List<GameObject> info = new List<GameObject>();


    public static void ObtainFuse(){
        instance.StartCoroutine(infoFloating(instance.info[4]));
    }
    public static void isHaveFuse(){
        if(fuse > 0){
            fuseBox = true;
            instance.StartCoroutine(infoFloating(instance.info[0]));
            instance.info[7].SetActive(true);
            Debug.Log("Fuse Terpasang");
        }else if(fuse < 1){
            Debug.Log("no fuse");
            instance.StartCoroutine(infoFloating(instance.info[1]));
        }
    }

    public static void isFusePlaced(){
        if(fuseBox){
            fuseButton = true;
            Debug.Log("Electricity On");
            instance.StartCoroutine(infoFloating(instance.info[3]));
            instance.info[8].SetActive(true);
        }else if(!fuseBox){
            Debug.Log("Need Fuse");
            instance.StartCoroutine(infoFloating(instance.info[2]));
        }
    }

    public static void isElectricityOn(){
        if(fuseButton){
            Debug.Log("Naik Lift");
            move.isUpLift = true;
            instance.StartCoroutine(infoFloating(instance.info[6]));
            instance.info[9].SetActive(true);
            instance.info[10].SetActive(true);
        }else if(!fuseButton){
            Debug.Log("Need Electricity");
            instance.StartCoroutine(infoFloating(instance.info[5]));
            Tutorial.pressLift = true;
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
                    instance = FindObjectOfType<GameManagerMap1>();

                    if(!instance)
                    {
                        instance = new GameObject ("GameManagerMap1").AddComponent<GameManagerMap1>();
                    }

                }
    }

    void Update(){
        
    }
}
