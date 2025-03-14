using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public List<ItemSO> inventory = new List<ItemSO>();


    public void AddItem(ItemSO item)
    {
        inventory.Add(item);
    }

    public void RemoveItem(ItemSO item)
    {
        inventory.Remove(item);
    }
}
