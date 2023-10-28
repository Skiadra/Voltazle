using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleObject : MonoBehaviour
{
    [SerializeField] private GameObject interactUI;
    public void onInteractable()
    {
        interactUI.SetActive(true);
    }

    public void notInteractable()
    {
        interactUI.SetActive(false);
    }
}
