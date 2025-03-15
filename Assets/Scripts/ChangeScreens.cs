using NaughtyAttributes;
using UnityEngine;
public class ChangeScreens : MonoBehaviour
{
    [SerializeField] GameObject nextScreen;
    [SerializeField] Transform spawnPos;
    [SerializeField] GameObject currentScreen;
    public bool isZoneChange = false;
    [ShowIf("isZoneChange")] public string zoneName;

    public void ScreenChange()
    {
        Fader.instance.StartFader(currentScreen, nextScreen, spawnPos);

        if(isZoneChange)
        {
            ZoneInfo.instance.ChangeZoneInfo(zoneName);
        }
    }
}
