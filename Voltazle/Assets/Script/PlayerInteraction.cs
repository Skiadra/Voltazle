using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public List<string> objectTags = new List<string>();
    public GameObject puzzle;
    private bool interactable = false;

    private void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.CompareTag(objectTags[0]))
        {
            obj.gameObject.transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
            interactable = true;
        }
    }

    private void OnTriggerExit2D(Collider2D obj)
    {
        if (obj.CompareTag(objectTags[0]))
        {
            obj.gameObject.transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
            interactable = false;
        }
    }

    void Update()
    {
        if (interactable && Input.GetKeyDown(KeyCode.E)){
            puzzle.SetActive(true);
            Debug.Log("True");}
    }
}
