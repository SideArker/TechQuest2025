using UnityEngine;
public class ChangeScreens : MonoBehaviour
{
    [SerializeField] GameObject nextScreen;
    [SerializeField] Transform spawnPos;
    [SerializeField] GameObject currentScreen;

    public void ScreenChange()
    {
        Fader.instance.StartFader(currentScreen, nextScreen, spawnPos);

    }
}
