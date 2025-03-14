using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ZoneInfo : MonoBehaviour
{
    [SerializeField] TMP_Text zoneText;
    Vector3 startPos = Vector3.zero;

    private void Start()
    {
        startPos = transform.position;
    }
    public void ChangeZoneInfo(string zoneName)
    {
        gameObject.transform.position = startPos;
        zoneText.text = zoneName;
        StartCoroutine(zoneAnim());
    }

    public IEnumerator zoneAnim()
    {
        gameObject.LeanMoveY(transform.position.y - 270, 0.5f).setEase(LeanTweenType.easeInOutQuad);
        yield return new WaitForSeconds(3f);
        gameObject.LeanMoveY(transform.position.y + 270, 0.5f).setEase(LeanTweenType.easeInOutQuad);

    }

}
