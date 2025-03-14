using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionManager : MonoBehaviour
{
    public void SendAction(string action)
    {
        if (!TurnManager.instance.isPlayerTurn) return;
        if(action == "Left")
        {
            TurnManager.instance.selectedSide = SelectedSide.Left;
        }
        else TurnManager.instance.selectedSide = SelectedSide.Right;
    }

    public void SpawnSigns(List<string> actions)
    {
        foreach (string action in actions)
        {

        }
    }
}
