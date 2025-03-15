using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour
{
    float startTime = 0;
    float holdTime = 4.0f;
    void Update()
    {
        if(Input.GetKey(KeyCode.Q))
        {
            startTime = Time.time;

            if(startTime + holdTime <= Time.time)
            {
                Application.Quit();
            }
        }

    }
}
