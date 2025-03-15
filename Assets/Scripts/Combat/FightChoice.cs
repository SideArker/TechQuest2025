using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FightChoice : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
    [SerializeField] ActionManager actionManager;
    [SerializeField] string side;
    [SerializeField] TMP_Text handText;
    [SerializeField] GameObject pointer;

    bool interactable = true;
    public void UpdateText()
    {
        Enemy enemy = TurnManager.instance.enemy;
        if(side == "Left")
        {
            if(enemy.leftSideHealth <= 0)
            {
                interactable = false;
                handText.transform.parent.GetComponent<Image>().color = Color.gray;
                handText.color = Color.gray;
            }
            handText.text = $"Lewa d³oñ\n{enemy.leftSideHealth}/50";
        }
        if(side == "Right")
        {
            if (enemy.rightSideHealth <= 0)
            {
                interactable = false;
                handText.transform.parent.GetComponent<Image>().color = Color.gray;
                handText.color = Color.gray;
            }

            handText.text = $"Prawa d³oñ\n{enemy.rightSideHealth}/50";
        }
        if(side == "Center")
        {
            handText.text = $"{enemy.centerHealth / 100}";
        }
    }

    private void Update()
    {
        UpdateText();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!interactable && !TurnManager.instance.isPlayerTurn) return;
        pointer.SetActive(false);
        actionManager.SendAction(side);
        transform.parent.gameObject.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!interactable) return;
        pointer.SetActive(true);
        pointer.transform.position = transform.position + Vector3.up * 150;
    }
}
