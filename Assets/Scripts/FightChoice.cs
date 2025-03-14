using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FightChoice : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
    [SerializeField] ActionManager actionManager;
    [SerializeField] string side;

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("new choice");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("a");
    }
}
