using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightInputController : MonoBehaviour
{
    public static FightInputController instance;
    public string currentKey;

    private void Awake()
    {
        instance = this;
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.A)) currentKey = "Left";
        else if (Input.GetKey(KeyCode.D)) currentKey = "Right";
        else if (Input.GetKey(KeyCode.W)) currentKey = "Up";
        else if (Input.GetKey(KeyCode.S)) currentKey = "Down";
        else currentKey = "Center";
    }
}