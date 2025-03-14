using UnityEngine;
public class ChangeScreens : MonoBehaviour
{
    [SerializeField] GameObject nextScreen;
    [SerializeField] Transform spawnPos;
    [SerializeField] GameObject currentScreen;

    public void ScreenChange()
    {
        nextScreen.SetActive(true);
        currentScreen.SetActive(false);

        PlayerController.instance.gameObject.transform.position = spawnPos.position;
    }
}
