using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [Header("Difficulty")]
    public int difficulty;
    public int dodges;
    public float timeBetweenDodges;

    [Header("Attacks")]
    public int damagePerHit;
    public int attacks;
    public float attackSpeed;

    [Header("Values")]
    public int leftSideHealth = 50;
    public int rightSideHealth = 50;
    public int centerHealth = 100;

    [SerializeField] Vector3 CenterPos;
    [SerializeField] Vector3 LeftPos;
    [SerializeField] Vector3 RightPos;
    [SerializeField] Vector3 UpPos;
    [SerializeField] Vector3 DownPos;

    Dictionary<string, Vector3> movePositionDictionary;
    List<string> moves = new List<string>() { "Left", "Right", "Up", "Down", "Center" };

    [SerializeField] DefendPanelManager defendManager;
    [SerializeField] Image CenterPiece;

    int amountOfHits;

    private void Start()
    {
        movePositionDictionary = new Dictionary<string, Vector3>()
        {
            {"Center", CenterPos },
            {"Left", LeftPos },
            {"Right", RightPos },
            {"Up", UpPos },
            {"Down", DownPos }
        };
    }

    public void ShowCenterPiece()
    {
        CenterPiece.gameObject.SetActive(true);
    }

    public IEnumerator StartDodging(List<string> moves)
    {
        for (int i = 0; i < moves.Count; i++)
        {
            transform.LeanMove(movePositionDictionary[moves[i]], .25f);
            yield return new WaitForSeconds(timeBetweenDodges + .25f);
            bool hit = TurnManager.instance.CheckIfHit(moves[i]);

            if (hit) TurnManager.instance.amountOfHits++;
        }
        transform.LeanMove(CenterPos, .35f);
        TurnManager.instance.DealDamageToEnemy();
    }

    public List<string> getMoves()
    {
        List<string> selectedMoves = new List<string>();

        for (int i = 0; i < attacks; i++)
        {
            string selectedMove = "";
            if (i == 0)
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
        }

        return selectedMoves;
    }

    public IEnumerator StartAttacking()
    {
        yield return new WaitForSeconds(1.5f);
        defendManager.gameObject.SetActive(true);
        yield return new WaitForSeconds(.5f); // Wait for player to regroup

        amountOfHits = 0;
        List<string> moves = getMoves();

        for(int i = 0; i < moves.Count; i++)
        {
            defendManager.ShowIcon(moves[i]);
            yield return new WaitForSeconds(1 / attackSpeed);
            bool hit = TurnManager.instance.CheckIfHit(moves[i]);
            if(!hit)
            {
                amountOfHits++;
            }
        }
        TurnManager.instance.DealDamageToPlayer(amountOfHits * damagePerHit);
        defendManager.gameObject.SetActive(false);
    }
}
