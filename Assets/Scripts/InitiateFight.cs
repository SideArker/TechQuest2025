using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitiateFight : MonoBehaviour
{
    [Scene]
    [SerializeField] int scene;


    public void StartFight()
    {
        Fader.instance.StartFader(scene);
        SceneManager.LoadScene(scene);
    }
}
