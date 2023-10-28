using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject2 : MonoBehaviour
{
    public enum InteractionType
    {
        None,
        Fuse1,
        Fuse2,
        FuseBox1,
        FuseBox2,
        FuseButton1,
        FuseButton2,
        LiftButton,
        // PuzzleButton,
        LaserButton,
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
                case InteractionType.FuseBox1:
                    GameManagerMap2.isHaveFuse();
                    break;
                case InteractionType.FuseBox2:
                    GameManagerMap2.isHaveFuse();
                    break;
                case InteractionType.FuseButton1:
                    GameManagerMap2.isFusePlaced1();
                    break;
                // case InteractionType.FuseButton2:
                //     GameManagerMap2.isFusePlaced2();
                //     break;
                case InteractionType.LiftButton:
                    // Lakukan tindakan mengambil objek
                    GameManagerMap2.isElectricityOn();
                    break;
                // case InteractionType.PuzzleButton:
                //     GameManagerMap2.isPuzzleOn();
                //     break;
                case InteractionType.LaserButton:
                    GameManagerMap2.isLaserOn();
                    break;
                // Tambahkan tindakan lain sesuai kebutuhan
                default:
                    Debug.Log("No interaction defined for " + gameObject.name);
                    break;
            }
        }
    }

    void Update(){
        if(isInRange && interactionType == InteractionType.Fuse1){
            GameManagerMap2.ObtainFuse1();
            GameManagerMap2.fuse++;
            Destroy(gameObject);
            
        }
        if(isInRange && interactionType == InteractionType.Fuse2){
            GameManagerMap2.ObtainFuse2();
            GameManagerMap2.fuse++;
            Destroy(gameObject);
        }
        if(Input.GetKeyDown(KeyCode.E)){
            Interact();
        }
    }
}
