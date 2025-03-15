using AYellowpaper.SerializedCollections;
using UnityEngine;
using UnityEngine.UI;

public class DefendPanelManager : MonoBehaviour
{
    [SerializedDictionary("Move", "IconObject")]
    public SerializedDictionary<string, Image> iconPairs = new SerializedDictionary<string, Image>();

    [SerializeField] Sprite attacked;
    [SerializeField] Sprite idle;

    public void ShowIcon(string move)
    {
        foreach (var pair in iconPairs)
        {
            pair.Value.sprite = idle;
        }
        iconPairs[move].sprite = attacked;
    }

}
