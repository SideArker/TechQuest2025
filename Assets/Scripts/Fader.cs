using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fader : MonoBehaviour
{
    public static Fader instance;

    private void Awake()
    {
        instance = this;
    }
    public void StartFader(GameObject currentRoom, GameObject nextRoom, Transform spawnPos)
    {
        StartCoroutine(fade(currentRoom, nextRoom, spawnPos));
    }

    public void StartFader(int sceneId)
    {
        StartCoroutine(fade(sceneId));
    }

    IEnumerator fade(GameObject currentRoom, GameObject nextRoom, Transform spawnPos)
    {
        PlayerController.instance.canMove = false;
        gameObject.LeanScale(new Vector3(25, 25, 25), .3f);
        yield return new WaitForSeconds(.4f);
        currentRoom.SetActive(false);
        nextRoom.SetActive(true);
        PlayerController.instance.gameObject.transform.position = spawnPos.position;
        gameObject.LeanScale(new Vector3(0, 0, 0), .3f);
        yield return new WaitForSeconds(.35f);
        PlayerController.instance.canMove = true;

    }

    IEnumerator fade(int sceneId)
    {
        gameObject.LeanScale(new Vector3(25, 25, 25), .3f);
        yield return new WaitForSeconds(.4f);
        SceneManager.LoadScene(sceneId);
        gameObject.LeanScale(new Vector3(0, 0, 0), .3f);
        yield break;

    }
}
