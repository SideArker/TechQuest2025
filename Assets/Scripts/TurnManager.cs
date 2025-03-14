using NaughtyAttributes;
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
    public Enemy enemy;
    public bool isPlayerTurn;
    public SelectedSide selectedSide;
    public int amountOfHits = 0;

    [SerializeField] int damageForHit = 3;

    List<string> moves = new List<string>() { "Left", "Right", "Up", "Down", "Center" };

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
        if (enemy.leftSideHealth <= 0 && enemy.rightSideHealth <= 0) WinFight();

        isPlayerTurn = true;
        StartCoroutine(WaitForChoice());
    }

    IEnumerator WaitForChoice()
    {
        yield return new WaitUntil(() => selectedSide != SelectedSide.None);

        AttackTurn();
    }

    [Button]
    void AttackTurn()
    {
        List<string> selectedMoves = new List<string>();

        for(int i = 0; i < enemy.dodges; i++)
        {
            string selectedMove = "";
            if(i == 0)
            {
                selectedMoves.Add(moves[Random.Range(0, 5)]);
                continue;
            }

            selectedMove = moves[Random.Range(0, 5)];
            while (selectedMove == selectedMoves[i - 1])
            {
                selectedMove = moves[Random.Range(0, 5)];
            }
            selectedMoves.Add(selectedMove);
            Debug.Log(selectedMoves[i]);
        }


        StartCoroutine(enemy.StartDodging(selectedMoves));
    }

    public void CheckIfHit(string currentMove)
    {
        if(currentMove == FightInputController.instance.currentKey)
        {
            Debug.Log("Hit!");
            amountOfHits++;
        }
        else
        {
            Debug.Log("Didn't hit!");
        }
    }

    public void DealDamageToEnemy()
    {
        if(selectedSide == SelectedSide.Left)
        {
            enemy.leftSideHealth -= amountOfHits * damageForHit;
        }
        if(selectedSide == SelectedSide.Right)
        {
            enemy.rightSideHealth -= amountOfHits * damageForHit;

        }
        isPlayerTurn = false;
    }

    void WinFight()
    {

    }

}
