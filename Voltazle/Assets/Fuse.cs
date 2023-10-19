using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuse : MonoBehaviour
{   
    [SerializeField] InventoryManager.AllItems itemType;
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Player")){
            InventoryManager.Instance.AddItem(itemType);
            InventoryManager.Instance.FuseCount++;
            Destroy(gameObject);
        }
    }
}
