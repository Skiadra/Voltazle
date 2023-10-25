using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public enum InteractionType
    {
        None,
        Fuse,
        FuseBox,
        FuseButton,
        LiftButton,
        // Tambahkan tindakan lain sesuai kebutuhan
    }

    public InteractionType interactionType = InteractionType.None;
    private bool isInRange = false;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = true;
            Debug.Log("Player is in range of " + gameObject.name);
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = false;
            Debug.Log("Player is out of range of " + gameObject.name);
        }
    }

    public void Interact()
    {
        if (isInRange)
        {
            // Lakukan tindakan berdasarkan interactionType
            switch (interactionType)
            {
                case InteractionType.FuseBox:
                    GameManagerMap1.isHaveFuse();
                    break;
                case InteractionType.FuseButton:
                    // Lakukan tindakan mengambil objek
                    GameManagerMap1.isFusePlaced();
                    break;
                case InteractionType.LiftButton:
                    // Lakukan tindakan mengambil objek
                    GameManagerMap1.isElectricityOn();
                    break;
                // Tambahkan tindakan lain sesuai kebutuhan
                default:
                    Debug.Log("No interaction defined for " + gameObject.name);
                    break;
            }
        }
    }

    void Update(){
        if(isInRange && interactionType == InteractionType.Fuse){
            GameManagerMap1.ObtainFuse();
            GameManagerMap1.fuse++;
            Destroy(gameObject);
            
        }
        if(Input.GetKeyDown(KeyCode.E)){
            Interact();
        }
    }
}
