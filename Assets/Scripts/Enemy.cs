using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int difficulty;
    public int dodges;
    public float timeBetweenDodges;
    public float attackSpeed;

    public int leftSideHealth = 50;
    public int rightSideHealth = 50;
    public int centerHealth = 50;

    [SerializeField] Vector3 CenterPos;
    [SerializeField] Vector3 LeftPos;
    [SerializeField] Vector3 RightPos;
    [SerializeField] Vector3 UpPos;
    [SerializeField] Vector3 DownPos;

    Dictionary<string, Vector3> movePositionDictionary;

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

    public IEnumerator StartDodging(List<string> moves)
    {
        for (int i = 0; i < moves.Count; i++)
        {
            transform.LeanMove(movePositionDictionary[moves[i]], .25f);
            yield return new WaitForSeconds(timeBetweenDodges + .25f);
            TurnManager.instance.CheckIfHit(moves[i]);
        }
        transform.LeanMove(CenterPos, .35f);
        TurnManager.instance.DealDamageToEnemy();
    }
}
