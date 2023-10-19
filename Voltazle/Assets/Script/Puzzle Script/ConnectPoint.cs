using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectPoint : MonoBehaviour
{

    SpriteRenderer sprite;
    public bool isOn = false;

    void OnTriggerStay2D(Collider2D obj)
    {
        if (obj.CompareTag("Cable"))
        {
            if (obj.transform.parent.GetComponent<PuzzleRotation>().on)
                isOn = true;
        }
    }

    void OnTriggerExit2D(Collider2D obj)
    {
        if (obj.CompareTag("Cable"))
        {
            isOn = false;
        }
    }
}
