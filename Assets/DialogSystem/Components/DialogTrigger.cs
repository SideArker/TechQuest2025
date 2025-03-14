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
        PlayerInventory playerInventory = PlayerController.instance.GetComponent<PlayerInventory>();
        List<DialogProperties> dialogQueue = new List<DialogProperties>();
        List<DialogProperties> pendingForRemove = new List<DialogProperties>();

        foreach (DialogProperties dialog in Dialogs)
        {
            if (dialog.InteractionReq > timesInteracted) continue;
            if(dialog.RequiredItem != null)
            {
                if (playerInventory.inventory.Contains(dialog.RequiredItem))
                {
                    pendingForRemove.Add(dialog);
                    continue;
                }
                else
                {
                    dialogQueue.Add(dialog);
                    break;
                }
            }
            dialogQueue.Add(dialog);
        }

        if (dialogQueue.Count <= 0) return;

        DialogSystem.instance.StopDialog();
        DialogSystem.instance.DialogQueue.AddRange(dialogQueue);
        DialogSystem.instance.NextDialog();

        timesInteracted++;

        foreach(DialogProperties dialog in dialogQueue)
        {
            if (dialog.OneTime) Dialogs.Remove(dialog);
            if (dialog.RequiredItem == playerInventory.inventory.Contains(dialog.RequiredItem) && dialog.RequiredItem != null) Dialogs.Remove(dialog);
        }

        foreach(DialogProperties dialog in pendingForRemove)
        {
            Dialogs.Remove(dialog);
        }
    }
}
