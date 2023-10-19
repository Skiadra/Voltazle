using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class ConnectPoint : MonoBehaviour
{
    public bool isOn;
    public bool entered = false;

    // void OnTriggerStay2D(Collider2D obj)
    // {
    //     if (obj.CompareTag("Cable"))
    //     {
    //         if (obj.transform.parent.GetComponent<PuzzleRotation>().on)
    //         {
    //             gameObject.transform.parent.GetComponent<PuzzleRotation>().on = true;
    //         }
    //         else
    //         {
    //             gameObject.transform.parent.GetComponent<PuzzleRotation>().on = false;
    //             obj.transform.parent.GetComponent<PuzzleRotation>().on = false;
    //         }
    //     }

    // }

    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.CompareTag("Cable"))
        {
            // if (obj.transform.parent.GetComponent<PuzzleRotation>().on)
            // {
            //     gameObject.transform.parent.GetComponent<PuzzleRotation>().on = true;
            // }
            // else
            // {
            //     if (gameObject.transform.parent.GetComponent<PuzzleRotation>().on)
            //         obj.transform.parent.GetComponent<PuzzleRotation>().on = true;
            //     else
            //         obj.transform.parent.GetComponent<PuzzleRotation>().on = false;
            // }

            gameObject.transform.parent.GetComponent<PuzzleRotation>().connections.Add(obj.transform.parent.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D obj)
    {
        if (obj.CompareTag("Cable"))
        {
            // if (gameObject.transform.parent.GetComponent<PuzzleRotation>().on)
            //     obj.transform.parent.GetComponent<PuzzleRotation>().on = false;
            // else
            //     obj.transform.parent.GetComponent<PuzzleRotation>().on = false;

            gameObject.transform.parent.GetComponent<PuzzleRotation>().connections.Remove(obj.transform.parent.gameObject);
            gameObject.transform.parent.transform.parent.GetComponent<PuzzleHead>().connected.Remove(obj.transform.parent.gameObject);
        }
    }
}
