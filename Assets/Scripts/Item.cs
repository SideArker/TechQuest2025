using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] ItemSO item;


    public void Interact()
    {
        PlayerController.instance.GetComponent<PlayerInventory>().AddItem(item);
        Destroy(gameObject);
    }

}
