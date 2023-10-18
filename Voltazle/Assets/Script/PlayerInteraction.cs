using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public List<string> objectTags = new List<string>();



    private void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.CompareTag(objectTags[0]))
        {
            obj.gameObject.transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D obj)
    {
        obj.gameObject.transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
    }
}
