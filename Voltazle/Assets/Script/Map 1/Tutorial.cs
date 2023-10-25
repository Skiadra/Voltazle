using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] public List<GameObject> tutorialObj = new List<GameObject>();
    public static bool pressLift = false;
    public static bool pressFuseButton = false;
    public static bool pressFuseBox = false;
    public static bool takeFuse;
    public static bool afterPressLift = false;
    public static bool afterPressFuseButton = false;
    public static bool afterPressFuseBox = false;
    int x = 0;
    void Start()
    {
        StartCoroutine(tutor(tutorialObj[0]));
        StartCoroutine(tutorArrow(tutorialObj[1]));
    }

    // Update is called once per frame
    void Update()
    {   
        if(pressLift){
            if(x == 0) {
                tutorialObj[1].SetActive(false);
                StartCoroutine(tutor(tutorialObj[2]));
                tutorialObj[3].SetActive(false);
                x++;
            }
        }

    }
    public static IEnumerator tutor(GameObject tutorialObj){
        tutorialObj.SetActive(true);
        yield return new WaitForSeconds(4f);
        tutorialObj.SetActive(false);
    }
    public static IEnumerator tutorArrow(GameObject tutorialObj){
        yield return new WaitForSeconds(3f);
        tutorialObj.SetActive(true);
    }
}
