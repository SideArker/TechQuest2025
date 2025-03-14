using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum SelectedSide
{
None,
Left,
Right,
Center
}


public class TurnManager : MonoBehaviour
{
    public static TurnManager instance;

    [SerializeField] Enemy enemy;
    SelectedSide selectedSide;
    List<string> moves = new List<string>() { "Left", "Right", "Top", "Bottom", "Center" };

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        BeginChoice();
    }

    void BeginChoice()
    {
        StartCoroutine(WaitForChoice());
    }

    IEnumerator WaitForChoice()
    {
        yield return new WaitUntil(() => selectedSide != SelectedSide.None);

        AttackTurn();
    }

    void AttackTurn()
    {
        List<string> selectedMoves = new List<string>();

        for(int i = 0; i < enemy.movesPerDefense; i++)
        {
            selectedMoves.Add(moves[Random.Range(0, 4)]);

            Debug.Log(selectedMoves[i]);
        }
    }

}
