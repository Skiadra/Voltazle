using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public int FuseCount = 0;
    public static InventoryManager Instance;
    public List<AllItems> inventoryItems = new List<AllItems>();

    private void Awake() {
        Instance = this;
    }

    //Add Items
    public void AddItem (AllItems item){
        if(!inventoryItems.Contains(item)){
            inventoryItems.Add(item);
        }
    }
    //Remove Items
    public void RemoveItem (AllItems item){
        if(inventoryItems.Contains(item)){
            inventoryItems.Remove(item);
        }
    }
    public enum AllItems
    {
        FuseGreen,
    }
}
