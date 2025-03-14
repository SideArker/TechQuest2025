using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    [SerializeField] List<DialogProperties> Dialogs = new List<DialogProperties>();
    public int timesInteracted;

    [Button]
    public void StartDialog()
    {
        List<DialogProperties> dialogQueue = new List<DialogProperties>();

        foreach (DialogProperties dialog in Dialogs)
        {
            if (dialog.InteractionReq > timesInteracted) continue;
            dialogQueue.Add(dialog);
        }

        DialogSystem.instance.StopDialog();
        DialogSystem.instance.DialogQueue.AddRange(dialogQueue);
        DialogSystem.instance.NextDialog();

        timesInteracted++;

        foreach(DialogProperties dialog in dialogQueue)
        {
            if(dialog.OneTime) Dialogs.Remove(dialog);
        }
    }
}
