using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

/// <summary>
/// Class containing the properties of given dialog
/// </summary>
[System.Serializable]
public class DialogProperties
{
    public string Name;
    [TextArea(10, 15)]
    public string Text;
    public Color NameColor = Color.white;
    public bool FreezeMovement = false;
    public int FontSize = 36;
    public int InteractionReq;
    public bool OneTime;
    public Sprite Sprite;
    public ItemSO RequiredItem;
    public UnityEvent DialogAction;

    public DialogProperties(string text, string name, Color nameColor, int fontSize = 36, bool freezeMovement = false, int interactionReq = 0, bool oneTime = false, Sprite sprite = null, ItemSO requiredItem = null, UnityEvent dialogAction = null)
    {
        if (nameColor == null) nameColor = Color.white;
        NameColor = nameColor;
        Text = text;
        Name = name;
        FontSize = fontSize;
        FreezeMovement = freezeMovement;
        InteractionReq = interactionReq;
        OneTime = oneTime;
        Sprite = sprite;
        RequiredItem = requiredItem;
        DialogAction = dialogAction;
    }
}


public class DialogSystem : MonoBehaviour
{
    [Header("Dialog Settings")]
    [SerializeField] TMP_Text dialogName;
    [SerializeField] TMP_Text dialogText;
    [SerializeField] TMP_Text popup;
    [SerializeField] GameObject continueTarget;
    [SerializeField] Image icon;

    [Header("Text Lerp")]
    [SerializeField] bool lerpText;
    [SerializeField] float timeBetweenLetters;
    bool skipLerp = false;

    TextShake TextShake;

    public static DialogSystem instance;

    public List<DialogProperties> DialogQueue = new List<DialogProperties>();


    public void StopDialog()
    {
        StopCoroutine(DialogTextLerp(""));
        dialogName.transform.parent.gameObject.SetActive(false);
        popup.gameObject.SetActive(false);
        continueTarget.SetActive(false);
        skipLerp = false;
        DialogQueue.Clear();

        TextShake.Shake(false, "", -1);

        // Enable player movement here
        //Player.instance.GetComponent<Movement>().enabled = true;
    }

    public void NextDialog()
    {
        PlayerController.instance.canMove = false;
        popup.gameObject.SetActive(false);
        skipLerp = false;
        StopCoroutine(DialogTextLerp(""));
        TextShake.Shake(false, "", -1);

        DialogProperties currentDialog;

        if (DialogQueue.Count == 0)
        {
            currentDialog = new DialogProperties("No new dialog data sent but dialog has started", "Error", Color.red);
        }
        else
        {
            currentDialog = DialogQueue[0];
            DialogQueue.RemoveAt(0);
        }
        string playerName = PlayerController.instance.Name;
        currentDialog.Text = currentDialog.Text.Replace("<name>", playerName);



        dialogName.text = currentDialog.Name;
        dialogName.color = (Color)currentDialog.NameColor;
        dialogText.text = currentDialog.Text;

        if (currentDialog.Sprite)
        {
            icon.gameObject.SetActive(true);
            icon.sprite = currentDialog.Sprite;
        }
        else
        {
            icon.gameObject.SetActive(false);
            icon.sprite = null;
        }
        

        if (dialogText.text.Contains("<shake>".ToLower().Trim()))
        {
            string result = TextShakeMarkFinder.FindMarker(dialogText);
            string slicedText = TextShakeMarkFinder.RemoveMarkers(dialogText);

            

            if(!string.IsNullOrEmpty(slicedText)) dialogText.text = slicedText;

            if (!string.IsNullOrEmpty(result)) TextShake.Shake(true, result, slicedText.IndexOf(result));

        }

        dialogName.transform.parent.gameObject.SetActive(true);
        continueTarget.SetActive(true);

        if (lerpText)
        {
            StartCoroutine(DialogTextLerp(dialogText.text));
        }
        else
        {
            popup.gameObject.SetActive(true);
        }

        currentDialog.DialogAction.Invoke();
    }


    IEnumerator DialogTextLerp(string text)
    {
        int index = 0;
        dialogText.text = "";

        while (dialogText.text != text)
        {
            if (skipLerp)
            {
                dialogText.text = text;
                popup.gameObject.SetActive(true);
                yield break;
            }

            if (text[index] == '<')
            {
                int closeMarkSymbol = text.IndexOf('>', index);
                if (closeMarkSymbol > -1)
                {
                    int diff = closeMarkSymbol - index + 1;

                    for(int i = 0; i < diff; i++)
                    {
                        dialogText.text += text[index];
                        index++;
                    }

                }
            }

            dialogText.text += text[index];
            index++;
            yield return new WaitForSeconds(timeBetweenLetters);
        }
        popup.gameObject.SetActive(true);
        skipLerp = true;
    }

    public void ContinueDialog()
    {
        if (!skipLerp && lerpText)
        {
            skipLerp = true;
        }
        else
        {
            if(DialogQueue.Count == 0)
            {
                StopDialog();
                PlayerController.instance.canMove = true;
            }
            else NextDialog();
        }

    }

    private void Awake()
    {
        instance = this;
        TextShake = dialogText.GetComponent<TextShake>();
    }
}
