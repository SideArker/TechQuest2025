using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class FightChoice : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
    [SerializeField] ActionManager actionManager;
    [SerializeField] string side;
    [SerializeField] TMP_Text handText;
    [SerializeField] GameObject pointer;


    public void UpdateText()
    {
        Enemy enemy = TurnManager.instance.enemy;
        if(side == "Left")
        {
            handText.text = $"Lewa d³oñ\n{enemy.leftSideHealth}/50";
        }
        else
        {
            handText.text = $"Prawa d³oñ\n{enemy.rightSideHealth}/50";
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        actionManager.SendAction(side);
        transform.parent.gameObject.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        pointer.transform.position = transform.position + Vector3.up * 150;
    }
}
