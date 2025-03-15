using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] TMP_Text hpText;
    Slider slider;
    float savedValue = 0;

    private void Start()
    {
        slider = GetComponent<Slider>();
    }

    private void Update()
    {

        slider.value = TurnManager.instance.playerHealth / 50;
        hpText.text = $"{TurnManager.instance.playerHealth} / 50";

    }
}
