using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public void Play()
    {
        Fader.instance.StartFader(1);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
