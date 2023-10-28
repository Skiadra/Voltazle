using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public List<string> objectTags = new List<string>();
    public GameObject puzzle;
    GameObject test;
    private bool interactable = false;
    [NonSerialized] public GameObject interactableObject;
    [NonSerialized] public bool clear = false;

    private void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.CompareTag(objectTags[0]) && !clear)
        {
            interactableObject = obj.gameObject;
            // obj.gameObject.transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
            obj.GetComponent<PuzzleObject>().onInteractable();
            interactable = true;
        }
    }

    private void OnTriggerExit2D(Collider2D obj)
    {
        if (obj.CompareTag(objectTags[0]))
        {
            // obj.gameObject.transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
            obj.GetComponent<PuzzleObject>().notInteractable();
            interactable = false;
        }
    }

    void Update()
    {
        if (interactable && Input.GetKeyDown(KeyCode.E) && test == null && !clear)
        {
            test = Instantiate(puzzle);
            test.transform.parent = GameObject.FindWithTag("MainCamera").transform;
            test.transform.localPosition = new Vector3(0, 0, 10);
            Debug.Log("True");
        }
    }
}
