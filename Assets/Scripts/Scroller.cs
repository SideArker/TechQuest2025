using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroller : MonoBehaviour
{
    [Range(-1f, 10f)] public float speed;
    public float offset;
    public Material mat;

    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        offset += (Time.deltaTime * speed) / 50;
        mat.SetTextureOffset("_MainTex", new Vector2 (offset, -offset));
    }
}
